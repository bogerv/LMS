using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(LMS.WebApi.Startup))]

namespace LMS.WebApi
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

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            app.MapSignalR();
        }
    }
}
