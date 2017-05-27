using LMS.Base;
using LMS.Teams;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.RecTeams
{
    [Table("RecTeam")]
    public class RecTeam : CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// 使用RecTeam表的主键(唯一Id)
        /// </summary>
        [Required]
        public virtual Guid TableId { get; set; }
        /// <summary>
        /// Team表Id
        /// </summary>
        [Required]
        public virtual Guid TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
