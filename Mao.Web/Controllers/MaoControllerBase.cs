using Abp.Web.Mvc.Controllers;

namespace Mao.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class MaoControllerBase : AbpController
    {
        protected MaoControllerBase()
        {
            LocalizationSourceName = MaoConsts.LocalizationSourceName;
        }
    }
}