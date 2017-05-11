using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Authorization.Roles.RoleGroups
{
    [Table("RoleGroup")]
    public class RoleGroup : FullAuditedEntity
    {
        /// <summary>
        /// 角色分组名称
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
