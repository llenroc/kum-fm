using Abp.Web.Mvc.Views;

namespace Mao.Web.Views
{
    public abstract class MaoWebViewPageBase : MaoWebViewPageBase<dynamic>
    {

    }

    public abstract class MaoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MaoWebViewPageBase()
        {
            LocalizationSourceName = MaoConsts.LocalizationSourceName;
        }
    }
}