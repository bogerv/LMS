using System.Linq;
using Abp.Authorization;
using Abp.Localization;

namespace LMS.Authorization.Roles.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="RolePermissions"/> for all permission names.
    /// </summary>
    public class RoleAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Role 的权限。
            var pages = context.GetPermissionOrNull(LmsPermissions.Pages) ?? context.CreatePermission(LmsPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LmsPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LmsPermissions.Pages_Administration, L("Administration"));

            var role = entityNameModel.CreateChildPermission(RolePermissions.Role, L("Role"));
            role.CreateChildPermission(RolePermissions.Role_CreateRole, L("CreateRole"));
            role.CreateChildPermission(RolePermissions.Role_EditRole, L("EditRole"));
            role.CreateChildPermission(RolePermissions.Role_DeleteRole, L("DeleteRole"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}