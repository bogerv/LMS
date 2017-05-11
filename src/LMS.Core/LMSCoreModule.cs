using System.Reflection;
using Abp.Modules;

namespace LMS
{
    public class LMSCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
