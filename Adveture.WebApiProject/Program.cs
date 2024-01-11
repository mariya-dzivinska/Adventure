using System.Net;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Xml.Xsl;
using Adventure.Business;
using Adveture.WebApiProject;
using Dapper;
using FluentMigrator.Runner;
using LeaningPass.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

public class Program
{
    private static IConfigurationRoot config;

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });
        builder.Services.AddAuthorization();

        config = InitConfig();

        builder.Services.AddSingleton<IConfiguration>(config);
        builder.Services.AddTransient<ITeachersService, TeachersService>();
        builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();

        builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSqlServer2012()
                .WithGlobalConnectionString(config.GetConnectionString("LearningPass"))
                .ScanIn(typeof(DatabaseContext).Assembly).For.Migrations());


        builder.Services.AddSingleton<DatabaseContext>();
        builder.Services.AddSingleton<Database>();


        var app = builder.Build();

        app.MigrateDatabase(config.GetValue(typeof(string),"DBName").ToString());
       
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


        app.UseMiddleware<CustomMiddleware>();

        app.UseMiddleware<MyLoggingMiddleware>();

        app.Run();
    }

    static IConfigurationRoot InitConfig()
    {
        var builder = new ConfigurationBuilder();

        var launchSettinsenv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: false, reloadOnChange: true);

        return builder.Build();

    }
}
