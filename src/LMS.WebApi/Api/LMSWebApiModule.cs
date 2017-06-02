using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;

namespace LMS.Api
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

            // override ForAll method
            //Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            //    .For<IUserAppService>("tasksystem/task")
            //    .ForMethod("CreateTask").DontCreateAction().Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
            ConfigureSwaggerUi();
        }

        public void ConfigureSwaggerUi()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var xmlFileName = "Bin//LMS.Application.xml";
            var xmlFile = Path.Combine(baseDir, xmlFileName);
            //Configuration.Modules.AbpWebApi().HttpConfiguration.EnableSwagger(c =>
            //{
            //    c.SingleApiVersion("v1.0", "LMS.WebApi文档");
            //    c.IncludeXmlComments(xmlFile);
            //    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            //})
            //.EnableSwaggerUi("api/documents/{*assetPath}", b=> {
            //    b.InjectJavaScript(Assembly.GetExecutingAssembly(), "LMS.WebApi.SwaggerUi.scripts.swagger.js");
            //});
        }
    }
}
