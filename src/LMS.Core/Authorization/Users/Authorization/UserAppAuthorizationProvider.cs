using System.Linq;
using Abp.Authorization;
using Abp.Localization;

namespace LMS.Authorization.Users.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="UserAppPermissions"/> for all permission names.
    /// </summary>
    public class UserAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了User 的权限。
            var pages = context.GetPermissionOrNull(LMSPermissions.Pages) ?? context.CreatePermission(LMSPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LMSPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LMSPermissions.Pages_Administration, L("Administration"));

            var user = entityNameModel.CreateChildPermission(UserAppPermissions.User, L("User"));
            user.CreateChildPermission(UserAppPermissions.User_CreateUser, L("CreateUser"));
            user.CreateChildPermission(UserAppPermissions.User_EditUser, L("EditUser"));
            user.CreateChildPermission(UserAppPermissions.User_DeleteUser, L("DeleteUser"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LMSConsts.LocalizationSourceName);
        }
    }
}