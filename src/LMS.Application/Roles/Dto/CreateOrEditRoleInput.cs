using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS.Roles
{
    public class CreateOrEditRoleInput
    {
        [Required]
        public RoleEditDto Role { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}
