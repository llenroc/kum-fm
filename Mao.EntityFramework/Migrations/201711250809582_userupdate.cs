namespace Mao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdate : DbMigration
    {
        public override void Up()
        {
            //É¾³ýË÷Òý
            Sql("DROP INDEX IX_CreatorUserId ON main_users");
            Sql("DROP INDEX IX_DeleterUserId ON main_users");
            Sql("DROP INDEX IX_LastModifierUserId ON main_users");
            Sql("alter table main_users drop foreign key FK_AbpUsers_AbpUsers_CreatorUserId;");
            Sql("alter table main_users drop foreign key FK_AbpUsers_AbpUsers_DeleterUserId;");
            Sql("alter table main_users drop foreign key FK_AbpUsers_AbpUsers_LastModifierUserId;");
           

            //DropForeignKey("Main_Users", "CreatorUserId", "AbpUsers",);
            //DropForeignKey("Main_Users", "DeleterUserId", "AbpUsers");
            //DropForeignKey("Main_Users", "LastModifierUserId", "AbpUsers");
            //DropIndex("Main_Users", new[] { "DeleterUserId" });
            //DropIndex("Main_Users", new[] { "LastModifierUserId" });
            //DropIndex("Main_Users", new[] { "CreatorUserId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Main_Users", "CreatorUserId");
            CreateIndex("dbo.Main_Users", "LastModifierUserId");
            CreateIndex("dbo.Main_Users", "DeleterUserId");
            AddForeignKey("dbo.Main_Users", "LastModifierUserId", "dbo.Main_Users", "Id");
            AddForeignKey("dbo.Main_Users", "DeleterUserId", "dbo.Main_Users", "Id");
            AddForeignKey("dbo.Main_Users", "CreatorUserId", "dbo.Main_Users", "Id");
        }
    }
}
