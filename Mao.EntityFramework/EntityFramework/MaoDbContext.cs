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
