using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Threading;
using LMS.Authorization.Users.Authorization;
using LMS.Web.Areas.Mpa.Models.Layout;
using LMS.Web.Controllers;

namespace LMS.Web.Areas.Mpa.Controllers
{
    public class LayoutController : LmsControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILocalizationManager _localizationManager;
        private readonly ILanguageManager _languageManager;
        //private readonly ISessionAppService _sessionAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        public LayoutController(IUserNavigationManager userNavigationManager, 
                                ILocalizationManager localizationManager,
                                ILanguageManager languageManager,
                                //ISessionAppService sessionAppService,
                                IMultiTenancyConfig multiTenancyConfig)
        {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
            _languageManager = languageManager;
            //_sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }

        [ChildActionOnly]
        public PartialViewResult SideMenu(string currentPageName = "")
        {
            var isGrantedPermission = PermissionChecker.IsGranted(AbpSession.ToUserIdentifier(), UserPermissions.User);
            var model = new SideMenuViewModel
            {
                MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("Mpa", AbpSession.ToUserIdentifier())),
                CurrentPageName = currentPageName
            };
            return PartialView("_SideMenu", model);
        }

        [ChildActionOnly]
        public PartialViewResult PersonInfo()
        {
            PersonInfoViewModel model;

            if (AbpSession.UserId.HasValue)
            {
                model = new PersonInfoViewModel
                {
                    //LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations()),
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                };
            }
            else
            {
                model = new PersonInfoViewModel
                {
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled
                };
            }

            return PartialView("_PersonInfo", model);
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages()
            };

            return PartialView("_LanguageSelection", model);
        }

        [ChildActionOnly]
        public PartialViewResult EmailNotification()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages()
            };

            return PartialView("_EmailNotification", model);
        }

        [ChildActionOnly]
        public PartialViewResult Notification()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages()
            };

            return PartialView("_Notification", model);
        }

        [ChildActionOnly]
        public PartialViewResult TaskNotification()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages()
            };

            return PartialView("_TaskNotification", model);
        }

        [ChildActionOnly]
        public PartialViewResult DropDownPersonMenu()
        {
            PersonInfoViewModel model;

            if (AbpSession.UserId.HasValue)
            {
                model = new PersonInfoViewModel
                {
                    //LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations()),
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                };
            }
            else
            {
                model = new PersonInfoViewModel
                {
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled
                };
            }

            return PartialView("_DropDownPersonMenu", model);
        }
    }
}