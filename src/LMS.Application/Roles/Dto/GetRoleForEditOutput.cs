using System.Collections.Generic;
using LMS.Permissions;

namespace LMS.Roles
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<GrantedPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
