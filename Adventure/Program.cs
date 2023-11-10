using System;
using System.Data;
using System.Drawing.Text;
using System.Reflection;
using System.Reflection.Metadata;
using Dapper;
using FluentMigrator.Runner;
using LeaningPass.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Z.Dapper.Plus;

namespace Adventure;

class Program
{

    private static IConfigurationRoot config;


    static void Main(string[] args)
    {
        InitConfig();

        var dbContext = new DatabaseContext(config);
        var database = new Database(dbContext);

        var dbName = config["DBName"];
        database.CreateDatabase(dbName);

        var serviceProvider = CreateServices();

        using (var scope = serviceProvider.CreateScope())
        {
            RunMigration(scope.ServiceProvider);
        }

        // Sql injection

        var id = Console.ReadLine();
        using (var connection = dbContext.CreateConnection())
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Id", id);
            var result = connection.Execute($"select* from Teacher where TeacherId = {id}",dynamicParameters);
        }

    }

    private static void RunMigration(IServiceProvider serviceProvider)
    {
        var migrationService = serviceProvider.GetRequiredService<IMigrationRunner>();
        migrationService.ListMigrations();
        migrationService.MigrateUp();

        migrationService.MigrateDown(202311090001);
        //migrationService.ListMigrations();
    }


    public static IServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSqlServer2012()
                .WithGlobalConnectionString(config.GetConnectionString("LearningPass"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .BuildServiceProvider(false);
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


    public void CheckAnonymousTypes()
    {
        dynamic inttype = new { FirstName = "sdf" };
        var firstNamea = inttype.FirstName;
        //inttype.Name = 1;
        //inttype.FirstName = 1;
        inttype = new Course();
        firstNamea = inttype.FirstName;

        dynamic strtype = "sldkfj";
        strtype = 10;
        dynamic obj = new { Name = 1 };

        var anounInt = 1;
        var anonStr = "sdf";
        var objAnon = new { Name = 1, LastName = "soeir" };
        //objAnon.Name = "sdkfj";
        var a = 1;
    }
}

