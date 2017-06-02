using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using LMS.Authorization.Roles;

namespace LMS.Roles
{
    [AutoMap(typeof(Role))]
    public class RoleEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }
    }
}
