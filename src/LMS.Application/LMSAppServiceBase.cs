using Abp.Application.Services;

namespace LMS
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class LMSAppServiceBase : ApplicationService
    {
        protected LMSAppServiceBase()
        {
            LocalizationSourceName = LMSConsts.LocalizationSourceName;
        }
    }
}