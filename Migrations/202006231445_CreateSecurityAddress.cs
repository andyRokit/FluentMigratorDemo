using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    [Migration(202006231445)]
    public class CreateSecurityAddress : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("address")
                .WithColumn("id").AsInt32().Identity().PrimaryKey("pk_security_address")
                .WithColumn("street").AsString().NotNullable()
                .WithColumn("town").AsString().NotNullable();
        }
    }
}
