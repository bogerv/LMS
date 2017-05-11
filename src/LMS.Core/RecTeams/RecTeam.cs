using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LMS.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.RecTeams
{
    [Table("RecTeam")]
    public class RecTeam : CreationAuditedEntity<Guid>, IMayHaveTenant
    {
        /// <summary>
        /// 使用RecTeam表的主键(唯一Id)
        /// </summary>
        [Required]
        public Guid TableId { get; set; }
        /// <summary>
        /// Team表Id
        /// </summary>
        [Required]
        public virtual Guid TeamId { get; set; }

        public int? TenantId { get; set; }

        public virtual Team Team { get; set; }
    }
}
