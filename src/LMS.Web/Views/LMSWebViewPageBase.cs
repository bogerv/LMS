using Abp.Web.Mvc.Views;

namespace LMS.Web.Views
{
    public abstract class LmsWebViewPageBase : LmsWebViewPageBase<dynamic>
    {

    }

    public abstract class LmsWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected LmsWebViewPageBase()
        {
            LocalizationSourceName = LmsConsts.LocalizationSourceName;
        }
    }
}