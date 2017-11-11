using Mao.EntityFramework;
using System.Data.Entity.Migrations;

namespace Mao.Migrations
{
   public sealed class Configuration : DbMigrationsConfiguration<MaoDbContext>
    {
        //public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Mao";
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        //protected override void Seed(EntityFramework.AbpZeroTemplateDbContext context)
        //{
        //    context.DisableAllFilters();

        //    context.EntityChangeEventHelper = NullEntityChangeEventHelper.Instance;
        //    context.EventBus = NullEventBus.Instance;

        //    if (Tenant == null)
        //    {
        //        //Host seed
        //        new InitialHostDbBuilder(context).Create();

        //        //Default tenant seed (in host database).
        //        new DefaultTenantBuilder(context).Create();
        //        new TenantRoleAndUserBuilder(context, 1).Create();
        //    }
        //    else
        //    {
        //        //You can add seed for tenant databases using Tenant property...
        //    }

        //    context.SaveChanges();
        //}
    }
}
