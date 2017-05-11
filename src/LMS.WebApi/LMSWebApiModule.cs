using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace LMS
{
    [DependsOn(typeof(AbpWebApiModule), typeof(LMSApplicationModule))]
    public class LMSWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(LMSApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
