using LMS.Authorization.Users;
using Microsoft.AspNet.Identity.Owin;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Abp.Domain.Services;
using Microsoft.Owin;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Authorization
{
    public class LmsSignInManager : SignInManager<User, Guid>, IDomainService
    {
        public LmsSignInManager(LmsUserManager userManager, IAuthenticationManager authenticationManager) 
            : base(userManager, authenticationManager)
        {
        }
    }
}