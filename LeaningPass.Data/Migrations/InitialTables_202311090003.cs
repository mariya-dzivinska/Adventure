using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations.Internal.InformationSchema;

namespace Adventure.Migrations
{
    [Migration(202311090003)]
    public class InitialTables_202311090003:Migration
    {
        public override void Up()
        {
            Create.Table("Teams")
                .WithColumn("TeamId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("TeamName").AsString(50).NotNullable()
                .WithColumn("Description").AsString(60).NotNullable()
                .WithColumn("City").AsString(50).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Teams");
        }
    }
}
