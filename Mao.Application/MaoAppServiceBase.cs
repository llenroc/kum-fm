using Abp.Application.Services;

namespace Mao
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MaoAppServiceBase : ApplicationService
    {
        protected MaoAppServiceBase()
        {
            LocalizationSourceName = MaoConsts.LocalizationSourceName;
        }
    }
}