using System.Reflection;
using Abp.Modules;

namespace LMS
{
    public class LmsCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
