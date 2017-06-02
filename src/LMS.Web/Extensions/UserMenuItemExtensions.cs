using System.Collections.Generic;
using Abp.Application.Navigation;
using LMS.Web.Views;

namespace LMS.Web.Extensions
{
    public static class UserMenuItemExtensions
    {
        /// <summary>
        /// Get a UserMenuItem's all sub menus, include itself
        /// </summary>
        /// <param name="menu">UserMenuItem</param>
        /// <returns></returns>
        public static List<UserMenuItem> Menus(this UserMenuItem menu)
        {
            List<UserMenuItem> list = new List<UserMenuItem>();
            list.Add(menu);
            GetSubMenus(menu, list);
            return list;
        }

        /// <summary>
        /// Get menu list recursive
        /// </summary>
        /// <param name="menu">UserMenuItem</param>
        /// <param name="allMenus">menu list</param>
        private static void GetSubMenus(UserMenuItem menu, List<UserMenuItem> allMenus)
        {
            allMenus.AddRange(menu.Items);
            foreach (var item in menu.Items)
            {
                GetSubMenus(item, allMenus);
            }
        }

        public static string CalculateUrl(this UserMenuItem menuItem, string applicationPath)
        {
            if (string.IsNullOrEmpty(menuItem.Url))
            {
                return applicationPath;
            }

            if (UrlChecker.IsRooted(menuItem.Url))
            {
                return menuItem.Url;
            }

            return applicationPath + menuItem.Url;
        }

        /// <summary>
        /// Is menu active in pages
        /// </summary>
        /// <param name="menuItem">menu</param>
        /// <param name="currentPageName">current page name</param>
        /// <returns></returns>
        public static bool IsMenuActive(this UserMenuItem menuItem, string currentPageName)
        {
            if (menuItem.Name == currentPageName)
            {
                return true;
            }

            if (menuItem.Items != null)
            {
                foreach (var item in menuItem.Items)
                {
                    if (item.Name == currentPageName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
