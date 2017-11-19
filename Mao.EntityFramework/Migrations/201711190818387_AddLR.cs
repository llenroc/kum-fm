namespace Mao.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddLR : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "AbpAuditLogs", newName: "Main_AuditLogs");
            RenameTable(name: "AbpBackgroundJobs", newName: "Main_BackgroundJobs");
            RenameTable(name: "AbpFeatures", newName: "Main_Features");
            RenameTable(name: "AbpEditions", newName: "Main_Editions");
            RenameTable(name: "AbpLanguages", newName: "Main_Languages");
            RenameTable(name: "AbpLanguageTexts", newName: "Main_LanguageTexts");
            RenameTable(name: "AbpNotifications", newName: "Main_Notifications");
            RenameTable(name: "AbpNotificationSubscriptions", newName: "Main_NotificationSubscriptions");
            RenameTable(name: "AbpOrganizationUnits", newName: "Main_OrganizationUnits");
            RenameTable(name: "AbpPermissions", newName: "Main_Permissions");
            RenameTable(name: "AbpRoles", newName: "Main_Roles");
            RenameTable(name: "AbpUsers", newName: "Main_Users");
            RenameTable(name: "AbpUserClaims", newName: "Main_UserClaims");
            RenameTable(name: "AbpUserLogins", newName: "Main_UserLogins");
            RenameTable(name: "AbpUserRoles", newName: "Main_UserRoles");
            RenameTable(name: "AbpSettings", newName: "Main_Settings");
            RenameTable(name: "AbpTenantNotifications", newName: "Main_TenantNotifications");
            RenameTable(name: "AbpTenants", newName: "Main_Tenants");
            RenameTable(name: "AbpUserAccounts", newName: "Main_UserAccounts");
            RenameTable(name: "AbpUserLoginAttempts", newName: "Main_UserLoginAttempts");
            RenameTable(name: "AbpUserNotifications", newName: "Main_UserNotifications");
            RenameTable(name: "AbpUserOrganizationUnits", newName: "Main_UserOrganizationUnits");
            CreateTable(
                "Base_AuthorizeData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorizeDataId = c.String(maxLength: 50, storeType: "nvarchar"),
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
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuthorizeData_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(maxLength: 50, storeType: "nvarchar"),
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
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Department_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_FilterIP",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterIP_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_FilterTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterTime_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_ModuleButton",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleButtonId = c.String(unicode: false),
                        ModuleId = c.String(unicode: false),
                        ParentId = c.String(unicode: false),
                        Icon = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        ActionAddress = c.String(unicode: false),
                        SortCode = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_ModuleColumn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleColumnId = c.String(unicode: false),
                        ModuleId = c.String(unicode: false),
                        ParentId = c.String(unicode: false),
                        EnCode = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        SortCode = c.Int(),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_ModuleForm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ModuleForm_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_ModuleFormInstance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormInstanceId = c.String(unicode: false),
                        FormId = c.String(unicode: false),
                        FormInstanceJson = c.String(unicode: false),
                        ObjectId = c.String(unicode: false),
                        SortCode = c.Int(),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_Organize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizeId = c.String(maxLength: 50, storeType: "nvarchar"),
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
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Organize_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_RoleLR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(maxLength: 50, storeType: "nvarchar"),
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
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RoleLR_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Base_UserRelation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRelationId = c.String(maxLength: 50, storeType: "nvarchar"),
                        UserId = c.String(unicode: false),
                        Category = c.Int(),
                        ObjectId = c.String(unicode: false),
                        IsDefault = c.Int(),
                        SortCode = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreateUserId = c.String(unicode: false),
                        CreateUserName = c.String(unicode: false),
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
                    { "DynamicFilter_UserRelation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Main_Users", "RealName", c => c.String(unicode: false));
            AddColumn("Main_Users", "NickName", c => c.String(unicode: false));
            AddColumn("Main_Users", "EnCode", c => c.String(unicode: false));
            AddColumn("Main_Users", "HeadIcon", c => c.String(unicode: false));
            AddColumn("Main_Users", "QuickQuery", c => c.String(unicode: false));
            AddColumn("Main_Users", "SimpleSpelling", c => c.String(unicode: false));
            AddColumn("Main_Users", "Gender", c => c.Int());
            AddColumn("Main_Users", "Birthday", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "Mobile", c => c.String(unicode: false));
            AddColumn("Main_Users", "Telephone", c => c.String(unicode: false));
            AddColumn("Main_Users", "Email", c => c.String(unicode: false));
            AddColumn("Main_Users", "OICQ", c => c.String(unicode: false));
            AddColumn("Main_Users", "WeChat", c => c.String(unicode: false));
            AddColumn("Main_Users", "MSN", c => c.String(unicode: false));
            AddColumn("Main_Users", "ManagerId", c => c.String(unicode: false));
            AddColumn("Main_Users", "Manager", c => c.String(unicode: false));
            AddColumn("Main_Users", "OrganizeId", c => c.String(unicode: false));
            AddColumn("Main_Users", "DepartmentId", c => c.String(unicode: false));
            AddColumn("Main_Users", "RoleId", c => c.String(unicode: false));
            AddColumn("Main_Users", "DutyId", c => c.String(unicode: false));
            AddColumn("Main_Users", "DutyName", c => c.String(unicode: false));
            AddColumn("Main_Users", "PostId", c => c.String(unicode: false));
            AddColumn("Main_Users", "PostName", c => c.String(unicode: false));
            AddColumn("Main_Users", "WorkGroupId", c => c.String(unicode: false));
            AddColumn("Main_Users", "SecurityLevel", c => c.Int());
            AddColumn("Main_Users", "UserOnLine", c => c.Int());
            AddColumn("Main_Users", "OpenId", c => c.Int());
            AddColumn("Main_Users", "Question", c => c.String(unicode: false));
            AddColumn("Main_Users", "AnswerQuestion", c => c.String(unicode: false));
            AddColumn("Main_Users", "CheckOnLine", c => c.Int());
            AddColumn("Main_Users", "AllowStartTime", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "AllowEndTime", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "LockStartDate", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "LockEndDate", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "FirstVisit", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "PreviousVisit", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "LastVisit", c => c.DateTime(precision: 0));
            AddColumn("Main_Users", "LogOnCount", c => c.Int());
            AddColumn("Main_Users", "SortCode", c => c.Int());
            AddColumn("Main_Users", "DeleteMark", c => c.Int());
            AddColumn("Main_Users", "EnabledMark", c => c.Int());
            AddColumn("Main_Users", "Description", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("Main_Users", "Description");
            DropColumn("Main_Users", "EnabledMark");
            DropColumn("Main_Users", "DeleteMark");
            DropColumn("Main_Users", "SortCode");
            DropColumn("Main_Users", "LogOnCount");
            DropColumn("Main_Users", "LastVisit");
            DropColumn("Main_Users", "PreviousVisit");
            DropColumn("Main_Users", "FirstVisit");
            DropColumn("Main_Users", "LockEndDate");
            DropColumn("Main_Users", "LockStartDate");
            DropColumn("Main_Users", "AllowEndTime");
            DropColumn("Main_Users", "AllowStartTime");
            DropColumn("Main_Users", "CheckOnLine");
            DropColumn("Main_Users", "AnswerQuestion");
            DropColumn("Main_Users", "Question");
            DropColumn("Main_Users", "OpenId");
            DropColumn("Main_Users", "UserOnLine");
            DropColumn("Main_Users", "SecurityLevel");
            DropColumn("Main_Users", "WorkGroupId");
            DropColumn("Main_Users", "PostName");
            DropColumn("Main_Users", "PostId");
            DropColumn("Main_Users", "DutyName");
            DropColumn("Main_Users", "DutyId");
            DropColumn("Main_Users", "RoleId");
            DropColumn("Main_Users", "DepartmentId");
            DropColumn("Main_Users", "OrganizeId");
            DropColumn("Main_Users", "Manager");
            DropColumn("Main_Users", "ManagerId");
            DropColumn("Main_Users", "MSN");
            DropColumn("Main_Users", "WeChat");
            DropColumn("Main_Users", "OICQ");
            DropColumn("Main_Users", "Email");
            DropColumn("Main_Users", "Telephone");
            DropColumn("Main_Users", "Mobile");
            DropColumn("Main_Users", "Birthday");
            DropColumn("Main_Users", "Gender");
            DropColumn("Main_Users", "SimpleSpelling");
            DropColumn("Main_Users", "QuickQuery");
            DropColumn("Main_Users", "HeadIcon");
            DropColumn("Main_Users", "EnCode");
            DropColumn("Main_Users", "NickName");
            DropColumn("Main_Users", "RealName");
            DropTable("Base_UserRelation",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRelation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("Base_RoleLR",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RoleLR_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("Base_Organize",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Organize_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("Base_ModuleFormInstance");
            DropTable("Base_ModuleForm",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ModuleForm_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("Base_ModuleColumn");
            DropTable("Base_ModuleButton");
            DropTable("Base_Module");
            DropTable("Base_FilterTime",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterTime_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("Base_FilterIP",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FilterIP_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("Base_Department",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Department_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("Base_AuthorizeData",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuthorizeData_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            RenameTable(name: "Main_UserOrganizationUnits", newName: "AbpUserOrganizationUnits");
            RenameTable(name: "Main_UserNotifications", newName: "AbpUserNotifications");
            RenameTable(name: "Main_UserLoginAttempts", newName: "AbpUserLoginAttempts");
            RenameTable(name: "Main_UserAccounts", newName: "AbpUserAccounts");
            RenameTable(name: "Main_Tenants", newName: "AbpTenants");
            RenameTable(name: "Main_TenantNotifications", newName: "AbpTenantNotifications");
            RenameTable(name: "Main_Settings", newName: "AbpSettings");
            RenameTable(name: "Main_UserRoles", newName: "AbpUserRoles");
            RenameTable(name: "Main_UserLogins", newName: "AbpUserLogins");
            RenameTable(name: "Main_UserClaims", newName: "AbpUserClaims");
            RenameTable(name: "Main_Users", newName: "AbpUsers");
            RenameTable(name: "Main_Roles", newName: "AbpRoles");
            RenameTable(name: "Main_Permissions", newName: "AbpPermissions");
            RenameTable(name: "Main_OrganizationUnits", newName: "AbpOrganizationUnits");
            RenameTable(name: "Main_NotificationSubscriptions", newName: "AbpNotificationSubscriptions");
            RenameTable(name: "Main_Notifications", newName: "AbpNotifications");
            RenameTable(name: "Main_LanguageTexts", newName: "AbpLanguageTexts");
            RenameTable(name: "Main_Languages", newName: "AbpLanguages");
            RenameTable(name: "Main_Editions", newName: "AbpEditions");
            RenameTable(name: "Main_Features", newName: "AbpFeatures");
            RenameTable(name: "Main_BackgroundJobs", newName: "AbpBackgroundJobs");
            RenameTable(name: "Main_AuditLogs", newName: "AbpAuditLogs");
        }
    }
}
