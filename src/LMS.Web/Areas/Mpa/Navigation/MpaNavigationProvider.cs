using Abp.Application.Navigation;
using Abp.Localization;
using LMS.Authorization;
using LMS.Authorization.Roles.Authorization;
using LMS.Authorization.Users.Authorization;
using LMS.Posts.Authorization;
using LMS.Teams.Authorization;

namespace LMS.Web.Areas.Mpa.Navigation
{
    public class MpaNavigationProvider : NavigationProvider
    {
        public const string MenuName = "Mpa";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            var administration = new MenuItemDefinition(
                PageNames.Common.Administration,
                L(PageNames.Common.Administration),
                "fa fa-cogs",
                requiredPermissionName: LmsPermissions.Pages_Administration
            );

            var user = new MenuItemDefinition(
                PageNames.Common.Users,
                L(PageNames.Common.Users),
                "fa fa-users",
                NavigationUrls.Users,
                requiredPermissionName: UserPermissions.User
            );

            var role = new MenuItemDefinition(
                PageNames.Common.Roles,
                L(PageNames.Common.Roles),
                "fa fa-users",
                NavigationUrls.Roles,
                requiredPermissionName: RolePermissions.Role
            );
            var job = new MenuItemDefinition(
                PageNames.Common.Jobs,
                L(PageNames.Common.Jobs),
                "fa fa-support",
                NavigationUrls.Jobs,
                requiredPermissionName: PostPermissions.Post
            );

            var team = new MenuItemDefinition(
                PageNames.Common.Teams,
                L(PageNames.Common.Teams),
                "fa fa-user-circle",
                NavigationUrls.Teams,
                requiredPermissionName: TeamPermissions.Team
            );

            menu.AddItem(
                    administration.AddItem(user).AddItem(role)
               ).AddItem(
                    job
               ).AddItem(
                    team
               );
        }

        protected static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}