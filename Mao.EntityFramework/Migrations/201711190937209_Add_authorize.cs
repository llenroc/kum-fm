namespace Mao.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_authorize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Base_Authorize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorizeId = c.String(maxLength: 50, storeType: "nvarchar"),
                        Category = c.Int(),
                        ObjectId = c.String(unicode: false),
                        ItemType = c.Int(),
                        ItemId = c.String(unicode: false),
                        SortCode = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Authorize_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Base_Authorize",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Authorize_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
