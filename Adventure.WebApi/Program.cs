using Dapper;
using FluentMigrator.Runner;
using LeaningPass.Data;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;


public class Program
{
    private static IConfigurationRoot config;

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        InitConfig();


        // Add services to the container.

        builder.Services.AddControllers();
            

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddSingleton(x => new DatabaseContext(config));
        builder.Services.AddSingleton<TeacherRepository>();

        //builder.Services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })

        //    // Adding Jwt Bearer
        //    .AddJwtBearer(options =>
        //    {
        //        options.SaveToken = true;
        //        options.RequireHttpsMetadata = false;
        //        options.TokenValidationParameters = new TokenValidationParameters()
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidAudience = config.GetValue<string>("JWT:ValidAudience"),
        //            ValidIssuer = config.GetValue<string>("JWT:ValidIssuer"),
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("JWT:Secret")))
        //        };
        //    });

        builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();


        builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSqlServer2012()
                .WithGlobalConnectionString(config.GetConnectionString("LearningPass"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .BuildServiceProvider(false);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        var dbContext = new DatabaseContext(config);
        var database = new Database(dbContext);

        var dbName = config["DBName"];
        database.CreateDatabase(dbName);

        var migrationService = app.Services.GetRequiredService<IMigrationRunner>();
        migrationService.ListMigrations();
        migrationService.MigrateUp();
    }


    private static void InitConfig()
    {
        var builder = new ConfigurationBuilder();

        var launchSettinsenv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: false, reloadOnChange: true);

        config = builder.Build();

        var a = config.GetConnectionString("LearningPass");

        var timeout = config["Timeout"];
    }
}

