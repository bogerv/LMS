using System.Reflection;
using Abp.Modules;
using LMS.Authorization.Permissions.Authorization;
using LMS.Authorization.Roles.Authorization;
using LMS.Authorization.Users.Authorization;
using LMS.Posts.Authorization;
using LMS.RPT.Projects.Authorization;
using LMS.RPT.Tasks.Authorization;
using LMS.Teams.Authorization;

namespace LMS
{
    [DependsOn(typeof(LmsCoreModule))]
    public class LmsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<UserAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<RoleAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<TaskAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<TeamAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PostAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ProjectAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PermissionAuthorizationProvider>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
