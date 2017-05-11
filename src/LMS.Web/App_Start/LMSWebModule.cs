using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using LMS.Web.Areas.Mpa.Navigation;
using Castle.MicroKernel.Registration;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using LMS.Authorization.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using LMS.EntityFramework;
using System;
using LMS.Authorization.Roles;

namespace LMS.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(LMSDataModule),
        typeof(LMSApplicationModule),
        typeof(LMSWebApiModule))]
    public class LMSWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));
            Configuration.Localization.Languages.Add(new LanguageInfo("ja", "日本語", "famfamfam-flag-jp"));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    LMSConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/LMS")
                        )
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<LMSNavigationProvider>();
            Configuration.Navigation.Providers.Add<MpaNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
                Component.For<IAuthenticationManager>()
                .UsingFactoryMethod(() => HttpContext.Current.GetOwinContext().Authentication)
                .LifestyleTransient()
                );
            //IocManager.IocContainer.Register(
            //    Component.For<IUserStore<User,Guid>>().ImplementedBy<LmsUserStore>(),
            //    Component.For<IRoleStore<Role, Guid>>().ImplementedBy<LmsRoleStore>()
            //    );

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
