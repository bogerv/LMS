using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using LMS.EntityFramework;

namespace LMS
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(LmsCoreModule))]
    public class LmsDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<LmsDbContext>(null);
        }
    }
}
