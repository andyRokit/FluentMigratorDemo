﻿using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    [Migration(202006231446)]
    public class AlterUserTable : Migration
    {
        public override void Up()
        {
            Alter.Table("user").AddColumn("address_id").AsInt32()
                .ForeignKey("fk_security_user_address", "address", "id");
        }

        public override void Down()
        {
            Delete.Column("address_id").FromTable("user");
        }
    }
}
