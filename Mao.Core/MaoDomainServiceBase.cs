using Abp.Domain.Services;

namespace Mao.Core
{
    public abstract class MaoDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected MaoDomainServiceBase()
        {
            LocalizationSourceName = MaoConsts.LocalizationSourceName;
        }
    }
}
