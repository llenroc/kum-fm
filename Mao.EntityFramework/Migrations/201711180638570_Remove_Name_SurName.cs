namespace Mao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Name_SurName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(maxLength: 256, storeType: "nvarchar"));
            DropColumn("dbo.AbpUsers", "Name");
            DropColumn("dbo.AbpUsers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 32, storeType: "nvarchar"));
            AddColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 32, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(nullable: false, maxLength: 256, storeType: "nvarchar"));
        }
    }
}
