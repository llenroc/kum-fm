using System.Linq;
using Mao.Core.MultiTenancy;
using Mao.Core.Editions;
using Mao.EntityFramework.EntityFramework;

namespace Mao.EntityFramework.Migrations.Seed.Tenants
{
    public class DefaultTenantBuilder
    {
        private readonly MaoDbContext _context;

        public DefaultTenantBuilder(MaoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultTenant();
        }

        private void CreateDefaultTenant()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Core.MultiTenancy.Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                defaultTenant = new Core.MultiTenancy.Tenant(Core.MultiTenancy.Tenant.DefaultTenantName, Core.MultiTenancy.Tenant.DefaultTenantName);

                var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
                if (defaultEdition != null)
                {
                    defaultTenant.EditionId = defaultEdition.Id;
                }

                _context.Tenants.Add(defaultTenant);
                _context.SaveChanges();
            }
        }
    }
}
