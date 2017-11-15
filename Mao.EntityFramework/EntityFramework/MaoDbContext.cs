using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;
using Mao.Core.Base;
using Mao.Core.Authorize;

namespace Mao.EntityFramework
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MaoDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public virtual IDbSet<Persons.Person> Persons { get; set; }
        public virtual IDbSet<DepartmentEntity> DepartmentEntity { get; set; }
        public virtual IDbSet<OrganizeEntity> OrganizeEntity { get; set; }
        public virtual IDbSet<RoleEntity> RoleEntity { get; set; }
       
        public virtual IDbSet<UserEntity> UserEntity { get; set; }

        public virtual IDbSet<UserRelationEntity> UserRelationEntity { get; set; }
        public virtual IDbSet<AuthorizeDataEntity> AuthorizeDataEntity { get; set; }
        public virtual IDbSet<FilterIPEntity> FilterIPEntity { get; set; }
        public virtual IDbSet<FilterTimeEntity> FilterTimeEntity { get; set; }
        public virtual IDbSet<ModuleButtonEntity> ModuleButtonEntity { get; set; }
        public virtual IDbSet<ModuleColumnEntity> ModuleColumnEntity { get; set; }
        public virtual IDbSet<ModuleEntity> ModuleEntity { get; set; }
        public virtual IDbSet<ModuleFormEntity> ModuleFormEntity { get; set; }
        public virtual IDbSet<ModuleFormInstanceEntity> ModuleFormInstanceEntity { get; set; }
      



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
    }
}
