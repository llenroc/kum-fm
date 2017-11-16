namespace Mao.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorizeDatas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AuthorizeDataId = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        AuthorizeType = c.Int(),
                        Category = c.Int(nullable: false),
                        ObjectId = c.String(unicode: false),
                        ItemId = c.String(unicode: false),
                        ItemName = c.String(unicode: false),
                        ResourceId = c.String(unicode: false),
                        IsRead = c.Int(nullable: false),
                        AuthorizeConstraint = c.String(unicode: false),
                        SortCode = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuthorizeData_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        OrganizeId = c.String(unicode: false),
                        ParentId = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        ShortName = c.String(unicode: false),
                        Nature = c.String(unicode: false),
                        ManagerId = c.String(unicode: false),
                        Manager = c.String(unicode: false),
                        OuterPhone = c.String(unicode: false),
                        InnerPhone = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Fax = c.String(unicode: false),
                        Layer = c.Int(),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        Description = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Department_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FilterIPs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FilterIPId = c.String(unicode: false),
                        ObjectType = c.String(unicode: false),
                        ObjectId = c.String(unicode: false),
                        VisitType = c.Int(),
                        Type = c.Int(),
                        IPLimit = c.String(unicode: false),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        Description = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterIP_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FilterTimes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FilterTimeId = c.String(unicode: false),
                        ObjectType = c.String(unicode: false),
                        ObjectId = c.String(unicode: false),
                        VisitType = c.Int(),
                        WeekDay1 = c.String(unicode: false),
                        WeekDay2 = c.String(unicode: false),
                        WeekDay3 = c.String(unicode: false),
                        WeekDay4 = c.String(unicode: false),
                        WeekDay5 = c.String(unicode: false),
                        WeekDay6 = c.String(unicode: false),
                        WeekDay7 = c.String(unicode: false),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        Description = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterTime_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ModuleId = c.String(unicode: false),
                        ParentId = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        Icon = c.String(unicode: false),
                        UrlAddress = c.String(unicode: false),
                        Target = c.String(unicode: false),
                        IsMenu = c.Int(),
                        AllowExpand = c.Int(),
                        IsPublic = c.Int(),
                        AllowEdit = c.Int(),
                        AllowDelete = c.Int(),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        Description = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Module_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ModuleButtons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ModuleButtonId = c.String(unicode: false),
                        ModuleId = c.String(unicode: false),
                        ParentId = c.String(unicode: false),
                        Icon = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        ActionAddress = c.String(unicode: false),
                        SortCode = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ModuleColumns",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ModuleColumnId = c.String(unicode: false),
                        ModuleId = c.String(unicode: false),
                        ParentId = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        SortCode = c.Int(),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ModuleForms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FormId = c.String(unicode: false),
                        ModuleId = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        FormJson = c.String(unicode: false),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        Description = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ModuleForm_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ModuleFormInstances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FormInstanceId = c.String(unicode: false),
                        FormId = c.String(unicode: false),
                        FormInstanceJson = c.String(unicode: false),
                        ObjectId = c.String(unicode: false),
                        SortCode = c.Int(),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Organizes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OrganizeId = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Category = c.Int(),
                        ParentId = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        ShortName = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        Nature = c.String(unicode: false),
                        OuterPhone = c.String(unicode: false),
                        InnerPhone = c.String(unicode: false),
                        Fax = c.String(unicode: false),
                        Postalcode = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        ManagerId = c.String(unicode: false),
                        Manager = c.String(unicode: false),
                        ProvinceId = c.String(unicode: false),
                        CityId = c.String(unicode: false),
                        CountyId = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        WebAddress = c.String(unicode: false),
                        FoundedTime = c.DateTime(precision: 0),
                        BusinessScope = c.String(unicode: false),
                        Layer = c.Int(),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Organize_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        age = c.Int(nullable: false),
                        sex = c.Boolean(nullable: false),
                        time = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Person_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        OrganizeId = c.String(unicode: false),
                        Category = c.Int(),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        IsPublic = c.Int(),
                        OverdueTime = c.DateTime(precision: 0),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        TenantId = c.Int(),
                        EnCode = c.String(unicode: false),
                        Account = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Secretkey = c.String(unicode: false),
                        RealName = c.String(unicode: false),
                        NickName = c.String(unicode: false),
                        HeadIcon = c.String(unicode: false),
                        QuickQuery = c.String(unicode: false),
                        SimpleSpelling = c.String(unicode: false),
                        Gender = c.Int(),
                        Birthday = c.DateTime(precision: 0),
                        Mobile = c.String(unicode: false),
                        Telephone = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        OICQ = c.String(unicode: false),
                        WeChat = c.String(unicode: false),
                        MSN = c.String(unicode: false),
                        ManagerId = c.String(unicode: false),
                        Manager = c.String(unicode: false),
                        OrganizeId = c.String(unicode: false),
                        DepartmentId = c.String(unicode: false),
                        RoleId = c.String(unicode: false),
                        DutyId = c.String(unicode: false),
                        DutyName = c.String(unicode: false),
                        PostId = c.String(unicode: false),
                        PostName = c.String(unicode: false),
                        WorkGroupId = c.String(unicode: false),
                        SecurityLevel = c.Int(),
                        UserOnLine = c.Int(),
                        OpenId = c.Int(),
                        Question = c.String(unicode: false),
                        AnswerQuestion = c.String(unicode: false),
                        CheckOnLine = c.Int(),
                        AllowStartTime = c.DateTime(precision: 0),
                        AllowEndTime = c.DateTime(precision: 0),
                        LockStartDate = c.DateTime(precision: 0),
                        LockEndDate = c.DateTime(precision: 0),
                        FirstVisit = c.DateTime(precision: 0),
                        PreviousVisit = c.DateTime(precision: 0),
                        LastVisit = c.DateTime(precision: 0),
                        LogOnCount = c.Int(),
                        SortCode = c.Int(),
                        DeleteMark = c.Int(),
                        EnabledMark = c.Int(),
                        Description = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserRelations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserRelationId = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        UserId = c.String(unicode: false),
                        Category = c.Int(),
                        ObjectId = c.String(unicode: false),
                        IsDefault = c.Int(),
                        SortCode = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreateUserId = c.String(unicode: false),
                        CreateUserName = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.String(unicode: false),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.String(unicode: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRelation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRelations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRelation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Users",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Roles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.People",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Person_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Organizes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Organize_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ModuleFormInstances");
            DropTable("dbo.ModuleForms",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ModuleForm_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ModuleColumns");
            DropTable("dbo.ModuleButtons");
            DropTable("dbo.Modules",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Module_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.FilterTimes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterTime_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.FilterIPs",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterIP_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Departments",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Department_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AuthorizeDatas",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuthorizeData_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
