namespace Mao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolelr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Base_RoleLR", "Description", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Base_RoleLR", "Description");
        }
    }
}
