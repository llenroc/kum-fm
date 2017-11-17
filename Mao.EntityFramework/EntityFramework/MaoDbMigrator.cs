using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Mao.EntityFramework;
using Mao.Migrations;

namespace Mao.EntityFramework
{
    public class MaoDbMigrator : AbpZeroDbMigrator<MaoDbContext, Configuration>
    {
        public MaoDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IIocResolver iocResolver) :
            base(
                unitOfWorkManager,
                connectionStringResolver,
                iocResolver)
        {

        }
    }
}
