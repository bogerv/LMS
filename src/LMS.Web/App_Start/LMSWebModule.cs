using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Modules;
using Abp.Web.Mvc;
using LMS.Web.Areas.Mpa.Navigation;
using Castle.MicroKernel.Registration;
using Microsoft.Owin.Security;
using Abp.Localization.Dictionaries.Json;
using LMS.Api;
using LMS.Web.Bundules;

namespace LMS.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(LmsDataModule),
        typeof(LmsApplicationModule),
        typeof(LmsWebApiModule))]
    public class LmsWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            //Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));
            //Configuration.Localization.Languages.Add(new LanguageInfo("ja", "日本語", "famfamfam-flag-jp"));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
               new DictionaryBasedLocalizationSource(
                   LmsConsts.LocalizationSourceName,
                   new JsonFileLocalizationDictionaryProvider(
                       HttpContext.Current.Server.MapPath("~/Localization/LMS/Json")
                       )
                   )
               );
            //Configuration.Localization.Sources.Add(
            //    new DictionaryBasedLocalizationSource(
            //        LmsConsts.LocalizationSourceName,
            //        new XmlFileLocalizationDictionaryProvider(
            //            HttpContext.Current.Server.MapPath("~/Localization/LMS")
            //            )
            //        )
            //    );

            Configuration.MultiTenancy.IsEnabled = false;

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<LmsNavigationProvider>();
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

            //Areas
            AreaRegistration.RegisterAllAreas();

            //Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Bundles
            BundleTable.Bundles.IgnoreList.Clear();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CommonBundleConfig.RegisterBundles(BundleTable.Bundles);
            AdminBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
