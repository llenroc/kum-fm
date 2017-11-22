namespace Mao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserrelation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Base_UserRelation", "CreateDate");
            DropColumn("dbo.Base_UserRelation", "CreateUserId");
            DropColumn("dbo.Base_UserRelation", "CreateUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Base_UserRelation", "CreateUserName", c => c.String(unicode: false));
            AddColumn("dbo.Base_UserRelation", "CreateUserId", c => c.String(unicode: false));
            AddColumn("dbo.Base_UserRelation", "CreateDate", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
