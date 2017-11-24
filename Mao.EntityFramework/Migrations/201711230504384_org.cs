namespace Mao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org : DbMigration
    {
        public override void Up()
        {
            AddColumn("Base_Organize", "Description", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("Base_Organize", "Description");
        }
    }
}
