using Abp.Web.Mvc.Views;

namespace LMS.Web.Views
{
    public abstract class LMSWebViewPageBase : LMSWebViewPageBase<dynamic>
    {

    }

    public abstract class LMSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected LMSWebViewPageBase()
        {
            LocalizationSourceName = LMSConsts.LocalizationSourceName;
        }
    }
}