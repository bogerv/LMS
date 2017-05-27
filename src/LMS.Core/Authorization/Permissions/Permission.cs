using LMS.RecTeams;
using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Timing;
using LMS.Authorization.Users;
using LMS.Base;

namespace LMS.Authorization.Permissions
{
    public class Permission : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public Guid ParentId { get; set; }
        public Permission Parent { get; set; }

        public virtual ICollection<Permission> Children { get; set; } = new HashSet<Permission>();
        public virtual ICollection<RecTeam> RecTeams { get; set; } = new HashSet<RecTeam>();

        protected Permission()
        {
            CreationTime = Clock.Now;
        }
    }
}
