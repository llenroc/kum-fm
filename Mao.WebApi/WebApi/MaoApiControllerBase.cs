//using Abp.WebApi.Controllers;
using Abp.WebApi.Controllers;
//using Mao.WebApi.Controllers;

namespace Mao.WebApi
{
    public abstract class MaoApiControllerBase : AbpApiController
    {
        protected MaoApiControllerBase()
        {
            LocalizationSourceName = MaoConsts.LocalizationSourceName;
        }
    }
}