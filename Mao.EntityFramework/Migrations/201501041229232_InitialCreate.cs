using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace MyCompanyName.KumZeroTemplate.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Kum_Base_User",
                c => new
                {
                    UserId = c.Long(nullable: false, identity: true),
                    EnCode = c.String(nullable: false, maxLength: 50),
                    Account = c.String(nullable: false, maxLength: 50),
                    Password = c.String(nullable: false, maxLength: 50),
                    Secretkey = c.String(nullable: false, maxLength: 50),
                    //-------
                    ManagerId = c.String(nullable: false, maxLength: 50),
                    Manager = c.String(nullable: false, maxLength: 50),
                    OrganizeId = c.String(nullable: false, maxLength: 50),
                    DepartmentId = c.String(nullable: false, maxLength: 50),
                    RoleId = c.String(nullable: false, maxLength: 50),
                    DutyId = c.String(nullable: false, maxLength: 50),
                    DutyName = c.String(nullable: false, maxLength: 50),
                    PostId = c.String(nullable: false, maxLength: 50),
                    PostName = c.String(nullable: false, maxLength: 50),
                    WorkGroupId = c.String(nullable: false, maxLength: 50),
                    SecurityLevel = c.Int(),
                    CheckOnLine = c.Int(),
                    SortCode = c.Int(),
                    //-------
                    AllowStartTime = c.DateTime(nullable: false),
                    AllowEndTime = c.DateTime(nullable: false),
                    LockStartDate = c.DateTime(nullable: false),
                    LockEndDate = c.DateTime(nullable: false),
                    //-------原生
                    IsDeleted = c.Boolean(nullable: false),
                    DeleterUserId = c.Long(),
                    DeletionTime = c.DateTime(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                });

            CreateTable(
                "dbo.Kum_Base_Role",
                c => new
                {
                    RoleId = c.String(nullable: false, maxLength: 50),
                    OrganizeId = c.String(nullable: false, maxLength: 50),
                    Category = c.Int(),
                    EnCode = c.String(nullable: false, maxLength: 50),
                    FullName = c.String(nullable: false, maxLength: 50),
                    IsPublic = c.Int(),
                    OverdueTime = c.DateTime(nullable: false),
                    SortCode = c.Int(),

                    Description = c.String(nullable: false, maxLength: 200),

                    //-------原生
                    IsDeleted = c.Boolean(nullable: false),
                    DeleterUserId = c.Long(),
                    DeletionTime = c.DateTime(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),

                });
            CreateTable(
                "dbo.Kum_Base_Organize",
                c => new
                {
                    Category = c.Int(),
                    ParentId = c.String(nullable: false, maxLength: 50),
                    EnCode = c.String(nullable: false, maxLength: 50),
                    ShortName = c.String(nullable: false, maxLength: 50),
                    FullName = c.String(nullable: false, maxLength: 50),
                    Nature = c.String(nullable: false, maxLength: 50),
                    OuterPhone = c.String(nullable: false, maxLength: 50),
                    InnerPhone = c.String(nullable: false, maxLength: 50),
                    Fax = c.String(nullable: false, maxLength: 50),
                    Postalcode = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false, maxLength: 50),
                    ManagerId = c.String(nullable: false, maxLength: 50),
                    Manager = c.String(nullable: false, maxLength: 50),
                    ProvinceId = c.String(nullable: false, maxLength: 50),
                    CityId = c.String(nullable: false, maxLength: 50),
                    CountyId = c.String(nullable: false, maxLength: 50),
                    Address = c.String(nullable: false, maxLength: 50),
                    WebAddress = c.String(nullable: false, maxLength: 50),
                    FoundedTime = c.DateTime(nullable: false),
                    BusinessScope = c.String(nullable: false, maxLength: 50),
                    Layer = c.Int(),
                    SortCode = c.Int(),

                    Description = c.String(nullable: false, maxLength: 200),


                    //-------原生
                    IsDeleted = c.Boolean(nullable: false),
                    DeleterUserId = c.Long(),
                    DeletionTime = c.DateTime(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),

                });

            CreateTable(
               "dbo.Kum_Base_Organize",
               c => new
               {

                   UserId = c.String(nullable: false, maxLength: 50),
                   Category = c.Int(),
                   ObjectId = c.String(nullable: false, maxLength: 50),
                   IsDefault = c.Int(),
                   SortCode = c.Int(),


                   //-------原生
                   IsDeleted = c.Boolean(nullable: false),
                   DeleterUserId = c.Long(),
                   DeletionTime = c.DateTime(),
                   LastModificationTime = c.DateTime(),
                   LastModifierUserId = c.Long(),
                   CreationTime = c.DateTime(nullable: false),
                   CreatorUserId = c.Long(),

               });



            CreateTable(
               "dbo.Kum_Base_Department",
               c => new
               {
                   OrganizeId = c.String(nullable: false, maxLength: 50),
                   ParentId = c.String(nullable: false, maxLength: 50),
                   EnCode = c.String(nullable: false, maxLength: 50),
                   FullName = c.String(nullable: false, maxLength: 50),
                   ShortName = c.String(nullable: false, maxLength: 50),
                   Nature = c.String(nullable: false, maxLength: 50),
                   ManagerId = c.String(nullable: false, maxLength: 50),
                   Manager = c.String(nullable: false, maxLength: 50),
                   OuterPhone = c.String(nullable: false, maxLength: 50),
                   InnerPhone = c.String(nullable: false, maxLength: 50),
                   Email = c.String(nullable: false, maxLength: 50),
                   Fax = c.String(nullable: false, maxLength: 50),
                   Layer = c.Int(),
                   SortCode = c.Int(),
                   
                   Description = c.String(nullable: false, maxLength: 200),


                   //-------原生
                   IsDeleted = c.Boolean(nullable: false),
                   DeleterUserId = c.Long(),
                   DeletionTime = c.DateTime(),
                   LastModificationTime = c.DateTime(),
                   LastModifierUserId = c.Long(),
                   CreationTime = c.DateTime(nullable: false),
                   CreatorUserId = c.Long(),

               });

        }

        public override void Down()
        {

        }
    }
}
