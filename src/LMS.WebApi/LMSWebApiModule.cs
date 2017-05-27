using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace LMS
{
    [DependsOn(typeof(AbpWebApiModule), typeof(LmsApplicationModule))]
    public class LmsWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(LmsApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
