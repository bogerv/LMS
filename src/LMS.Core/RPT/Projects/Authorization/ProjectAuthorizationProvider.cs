using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using LMS.Authorization;

namespace LMS.RPT.Projects.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// </summary>
    public class ProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Project 的权限。
            var pages = context.GetPermissionOrNull(LmsPermissions.Pages) ?? context.CreatePermission(LmsPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LmsPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LmsPermissions.Pages_Administration, L("Administration"));

            var Project = entityNameModel.CreateChildPermission(ProjectPermissions.Project, L("Project"));
            Project.CreateChildPermission(ProjectPermissions.Project_CreateProject, L("CreateProject"));
            Project.CreateChildPermission(ProjectPermissions.Project_EditProject, L("EditProject"));
            Project.CreateChildPermission(ProjectPermissions.Project_DeleteProject, L("DeleteProject"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}