using System.Linq;
using Abp.Authorization;
using Abp.Localization;

namespace LMS.Authorization.Permissions.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="PermissionPermissions"/> for all permission names.
    /// </summary>
    public class PermissionAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Permission 的权限。
            var pages = context.GetPermissionOrNull(LmsPermissions.Pages) ?? context.CreatePermission(LmsPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LmsPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LmsPermissions.Pages_Administration, L("Administration"));

            var Permission = entityNameModel.CreateChildPermission(PermissionPermissions.Permission, L("Permission"));
            Permission.CreateChildPermission(PermissionPermissions.Permission_CreatePermission, L("CreatePermission"));
            Permission.CreateChildPermission(PermissionPermissions.Permission_EditPermission, L("EditPermission"));
            Permission.CreateChildPermission(PermissionPermissions.Permission_DeletePermission, L("DeletePermission"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}