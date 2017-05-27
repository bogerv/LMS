using System;
using System.Web.Mvc;
using Abp.Authorization;

namespace LMS.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class LmsMvcAuthorizeAttribute : AuthorizeAttribute
    {
        public string[] Permissions { get; set; }

        public LmsMvcAuthorizeAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
