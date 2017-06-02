using System.Collections.Generic;
using LMS.Permissions;

namespace LMS.Web.Areas.Mpa.Models.Permissions
{
    public interface IPermissionsEditViewModel
    {
        List<GrantedPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}
