using Abp.Web.Mvc.Views;

namespace EarthLink.Web.Views
{
    public abstract class EarthLinkWebViewPageBase : EarthLinkWebViewPageBase<dynamic>
    {

    }

    public abstract class EarthLinkWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected EarthLinkWebViewPageBase()
        {
            LocalizationSourceName = EarthLinkConsts.LocalizationSourceName;
        }
    }
}