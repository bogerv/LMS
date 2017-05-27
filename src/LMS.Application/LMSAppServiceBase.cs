using Abp.Application.Services;

namespace LMS
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class LmsAppServiceBase : ApplicationService
    {
        protected LmsAppServiceBase()
        {
            LocalizationSourceName = LmsConsts.LocalizationSourceName;
        }
    }
}