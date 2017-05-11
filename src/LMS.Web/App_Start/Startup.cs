using LMS.Authorization.Users;
using Microsoft.AspNet.Identity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext<LmsUserManager>(LmsUserManager.Create);
            //app.CreatePerOwinContext<LmsRoleManager>(LmsRoleManager.Create);
            //app.CreatePerOwinContext<LmsSignInManager>(LmsSignInManager.Create);

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Account/Login")
            });
        }
    }
}