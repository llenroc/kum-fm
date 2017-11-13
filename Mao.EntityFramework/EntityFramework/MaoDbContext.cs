using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;

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
        public IDbSet<Persons.Person> Persons { get; set; }

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
