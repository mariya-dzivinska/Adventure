using System.Drawing;
using FluentMigrator.Runner;
using LeaningPass.Data;

namespace Adveture.WebApiProject
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host, string dbName)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
                var migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    databaseService.CreateDatabase(dbName);
                    migrationRunner.MigrateUp();
                }
                catch
                {
                    throw;
                }
            }

            return host;
        }
    }
}
