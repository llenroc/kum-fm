namespace Mao.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("Base_Module", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("Base_Module", "DeleterUserId", c => c.Long());
            AddColumn("Base_Module", "DeletionTime", c => c.DateTime(precision: 0));
            AddColumn("Base_Module", "LastModificationTime", c => c.DateTime(precision: 0));
            AddColumn("Base_Module", "LastModifierUserId", c => c.Long());
            AddColumn("Base_Module", "CreationTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("Base_Module", "CreatorUserId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("Base_Module", "CreatorUserId");
            DropColumn("Base_Module", "CreationTime");
            DropColumn("Base_Module", "LastModifierUserId");
            DropColumn("Base_Module", "LastModificationTime");
            DropColumn("Base_Module", "DeletionTime");
            DropColumn("Base_Module", "DeleterUserId");
            DropColumn("Base_Module", "IsDeleted");
          
            
        }
    }
}
