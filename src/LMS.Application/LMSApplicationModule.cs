using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using AutoMapper;
using LMS.Application;
using LMS.Authorization.Permissions.Authorization;
using LMS.Authorization.Roles.Authorization;
using LMS.Authorization.Users;
using LMS.Authorization.Users.Authorization;
using LMS.Authorization.Users.Dtos;
using LMS.Posts.Authorization;
using LMS.RPT.Projects.Authorization;
using LMS.RPT.Tasks.Authorization;
using LMS.Teams.Authorization;

namespace LMS
{
    [DependsOn(typeof(LmsCoreModule),typeof(AbpAutoMapperModule))]
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

            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
