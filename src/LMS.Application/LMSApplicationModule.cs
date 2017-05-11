using System.Reflection;
using Abp.Modules;
using LMS.Authorization.Users.Authorization;

namespace LMS
{
    [DependsOn(typeof(LMSCoreModule))]
    public class LMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<UserAppAuthorizationProvider>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
