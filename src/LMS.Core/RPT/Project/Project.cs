using Abp.Domain.Entities;
using LMS.Authorization.Users;
using LMS.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.RPT
{
    public class Project : EntityBase
    {
        public const int MaxProjectNameLength = 512;
        public string Name { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public Guid LeaderId { get; set; }
        /// <summary>
        /// 项目开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 项目结束时间
        /// </summary>
        public DateTime DueTime { get; set; }
        public string Des { get; set; }

        public virtual User Leader { get; set; }
    }
}
