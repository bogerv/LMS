using Abp.Domain.Uow;
using Abp.Localization;
using Abp.Runtime.Caching;
using Abp.Web.Models;
using Castle.Core.Logging;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LMS.Web.Controllers
{
    public class AccountController : LmsControllerBase
    {
        //private readonly SignInManager<User, Guid> _signInManager;
        private readonly LmsUserManager _userManager;
        private readonly LmsRoleManager _roleManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ICacheManager _cacheManager;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ILanguageManager _languageManager;
        public readonly ILogger _logger;

        public AccountController(
            LmsUserManager userManager,
            LmsRoleManager roleManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            //SignInManager<User, Guid> signInManager,
            IAuthenticationManager authenticationManager,
            ILanguageManager languageManager,
            ILogger logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWorkManager = unitOfWorkManager;
            _cacheManager = cacheManager;
            //_signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _languageManager = languageManager;
            _logger = logger;
        }

        #region 登录/退出
        [AllowAnonymous]
        public ActionResult Login(string userNameOrEmailAddress = "", string returnUrl = "", string successMessage = "")
        {
            return View(
                new LoginFormViewModel
                {
                    SuccessMessage = successMessage,
                    UserNameOrEmailAddress = userNameOrEmailAddress
                });
        }

        [HttpPost]
        [UnitOfWork]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(loginModel.UserNameOrEmailAddress, loginModel.Password);
                if (user != null)
                {
                    await SignInAsync(user, loginModel.RememberMe.Equals("on"));
                    return Redirect(GetRedirectUrl(returnUrl));
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return Json(new AjaxResponse { TargetUrl = GetRedirectUrl(returnUrl) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "User", new { area = "Mpa" });
            }

            return returnUrl;
        }

        #endregion

        #region 注册

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [UnitOfWork]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAsync(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = registerModel.UserName, Password = registerModel.Password, EmailAddress = registerModel.EmailAddress, Name = registerModel.Name };
                //var result = await _userManager.CreateAsync(user, registerModel.Password);
                //if (result.Succeeded)
                //{
                //    await SignInAsync(user, isPersistent: false);
                //    return RedirectToAction("Index", "Home");
                //}
            }
            //return View(registerModel);
            return Json("ok");
        }

        private async Task SignInAsync(User user, bool isPersistent)
        {
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        #endregion
    }
}