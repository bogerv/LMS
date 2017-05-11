using Abp.Application.Navigation;
using Abp.Localization;
using LMS.Authorization.Users.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web.Areas.Mpa.Navigation
{
    public class MpaNavigationProvider : NavigationProvider
    {
        public const string MenuName = "Mpa";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            var user = new MenuItemDefinition(
                UserAppPermissions.User,
                L("User"),
                url: "Mpa/UserManage",
                icon: "icon-grid"
            //,requiredPermissionName: UserAppPermissions.User
            );
            menu
                .AddItem(user);
        }

        protected static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LMSConsts.LocalizationSourceName);
        }
    }
}