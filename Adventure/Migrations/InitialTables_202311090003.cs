using FluentMigrator;
using System;
using System.Collections.Generic;
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
            Create.Table("Companies")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Address").AsString(60).NotNullable()
                .WithColumn("Country").AsString(50).NotNullable();
        }

        public override void Down()
        {
            

            Delete.Table("Companies");
        }
    }
}
