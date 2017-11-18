using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Mao.EntityFramework;
using Mao.EntityFramework.EntityFramework;
using Mao.Migrations;

namespace Mao.EntityFramework
{
    public class AbpZeroDbMigrator : AbpZeroDbMigrator<MaoDbContext, Configuration>
    {
        public AbpZeroDbMigrator(
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
