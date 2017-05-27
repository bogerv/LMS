using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using LMS.Authorization;

namespace LMS.Teams.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// </summary>
    public class TeamAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Team 的权限。
            var pages = context.GetPermissionOrNull(LmsPermissions.Pages) ?? context.CreatePermission(LmsPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LmsPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LmsPermissions.Pages_Administration, L("Administration"));

            var Team = entityNameModel.CreateChildPermission(TeamPermissions.Team, L("Team"));
            Team.CreateChildPermission(TeamPermissions.Team_CreateTeam, L("CreateTeam"));
            Team.CreateChildPermission(TeamPermissions.Team_EditTeam, L("EditTeam"));
            Team.CreateChildPermission(TeamPermissions.Team_DeleteTeam, L("DeleteTeam"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}