using System.Linq;
using Abp.Authorization;
using Abp.Localization;

namespace LMS.Authorization.Users.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="UserPermissions"/> for all permission names.
    /// </summary>
    public class UserAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了User 的权限。
            var pages = context.GetPermissionOrNull(LmsPermissions.Pages) ?? context.CreatePermission(LmsPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LmsPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LmsPermissions.Pages_Administration, L("Administration"));

            var user = entityNameModel.CreateChildPermission(UserPermissions.User, L("User"));
            user.CreateChildPermission(UserPermissions.User_CreateUser, L("CreateUser"));
            user.CreateChildPermission(UserPermissions.User_EditUser, L("EditUser"));
            user.CreateChildPermission(UserPermissions.User_DeleteUser, L("DeleteUser"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}