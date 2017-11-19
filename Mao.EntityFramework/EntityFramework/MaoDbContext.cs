using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;
using Mao.Core.Storage;
using Mao.Core.Friendships;
using Mao.Core.Chat;
using Abp.Zero.EntityFramework;
using Mao.Core.MultiTenancy;
using Mao.Core.Authorization.Roles;
using Mao.Core.Authorization.Users;
using Mao.Core.Base;
using Mao.Core.Authorize;

namespace Mao.EntityFramework.EntityFramework
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MaoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for each ...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public virtual IDbSet<Persons.Person> Persons { get; set; }

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public virtual IDbSet<Department> Department { get; set; }
        public virtual IDbSet<Organize> Organize { get; set; }
        public virtual IDbSet<RoleLR> Role { get; set; }


        public virtual IDbSet<UserRelation> UserRelation { get; set; }
        public virtual IDbSet<Authorize> Authorize { get; set; }
        public virtual IDbSet<AuthorizeData> AuthorizeData { get; set; }
        public virtual IDbSet<FilterIP> FilterIP { get; set; }
        public virtual IDbSet<FilterTime> FilterTime { get; set; }
        public virtual IDbSet<ModuleButton> ModuleButton { get; set; }
        public virtual IDbSet<ModuleColumn> ModuleColumn { get; set; }
        public virtual IDbSet<Module> Module { get; set; }
        public virtual IDbSet<ModuleForm> ModuleForm { get; set; }
        public virtual IDbSet<ModuleFormInstance> ModuleFormInstance { get; set; }


        public MaoDbContext()
            : base("Default")
        {



        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MaoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MaoDbContext since ABP automatically handles it.
         */
        public MaoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MaoDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MaoDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("Main_", "");

            string prefix = "Base_";

            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<Department>(modelBuilder, prefix+ "Department", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<Organize>(modelBuilder, prefix + "Organize", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<RoleLR>(modelBuilder, prefix + "RoleLR", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<UserRelation>(modelBuilder, prefix + "UserRelation", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<Authorize>(modelBuilder, prefix + "Authorize", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<AuthorizeData>(modelBuilder, prefix + "AuthorizeData", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<FilterIP>(modelBuilder, prefix + "FilterIP", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<FilterTime>(modelBuilder, prefix + "FilterTime", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<ModuleButton>(modelBuilder, prefix + "ModuleButton", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<ModuleColumn>(modelBuilder, prefix + "ModuleColumn", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<Module>(modelBuilder, prefix + "Module", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<ModuleForm>(modelBuilder, prefix + "ModuleForm", "");
            Abp.Zero.EntityFramework.AbpZeroDbModelBuilderExtensions.SetTableName<ModuleFormInstance>(modelBuilder, prefix + "ModuleFormInstance", "");


        }

    }


}
