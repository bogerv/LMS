using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web.Models.Account
{
    public class LoginFormViewModel
    {
        public string SuccessMessage { get; set; }
        public string UserNameOrEmailAddress { get; set; }
    }
}