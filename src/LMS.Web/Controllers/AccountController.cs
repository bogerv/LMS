using Abp.Domain.Uow;
using Abp.Localization;
using Abp.Runtime.Caching;
using Abp.Web.Models;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LMS.Web.Controllers
{
    public class AccountController : LMSControllerBase
    {
        //private readonly SignInManager<User, Guid> _signInManager;
        private readonly LmsUserManager _userManager;
        private readonly LmsRoleManager _roleManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ICacheManager _cacheManager;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ILanguageManager _languageManager;

        public AccountController(
            LmsUserManager userManager,
            LmsRoleManager roleManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            //SignInManager<User, Guid> signInManager,
            IAuthenticationManager authenticationManager,
            ILanguageManager languageManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWorkManager = unitOfWorkManager;
            _cacheManager = cacheManager;
            //_signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _languageManager = languageManager;
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
        public ActionResult Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }
            if (ModelState.IsValid)
            {
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, loginModel.UsernameOrEmailAddress),
                new Claim(ClaimTypes.Email, loginModel.Password),
            },
            "ApplicationCookie");

                //var ctx = Request.GetOwinContext();
                //var authManager = ctx.Authentication;

                _authenticationManager.SignIn(identity);
                //var result = await _signInManager.PasswordSignInAsync(loginModel.UsernameOrEmailAddress, loginModel.Password, loginModel.RememberMe, shouldLockout: false);
                //if (result == SignInStatus.Success)
                //{
                //    return Json(new AjaxResponse
                //    {
                //        TargetUrl = Url.Action(
                //            "SendSecurityCode",
                //            new
                //            {
                //                returnUrl = returnUrl,
                //                rememberMe = loginModel.RememberMe
                //            })
                //    });
                //}
                return Redirect(GetRedirectUrl(returnUrl));
            }

            return Json(new AjaxResponse { TargetUrl = returnUrl });
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
                return Url.Action("index", "UserManage", new { area = "Mpa" });
            }

            return returnUrl;
        }

        #endregion

        #region 注册

        public ActionResult Register()
        {
            return View();
        }

        #endregion
    }
}