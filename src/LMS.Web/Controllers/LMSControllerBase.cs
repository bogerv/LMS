using Abp.Web.Mvc.Controllers;

namespace LMS.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class LMSControllerBase : AbpController
    {
        protected LMSControllerBase()
        {
            LocalizationSourceName = LMSConsts.LocalizationSourceName;
        }
    }
}