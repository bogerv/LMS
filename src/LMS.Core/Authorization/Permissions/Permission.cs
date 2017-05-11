using Abp.Application.Features;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Localization;
using Abp.MultiTenancy;
using LMS.Base;
using LMS.RecTeams;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Authorization.Permissions
{
    public class Permission : CreationAuditedEntity<Guid>, IMayHaveTenant
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int? TenantId { get; set; }

        public Guid ParentId { get; set; }
        public Permission Parent { get; set; }
        public virtual ICollection<PermissionSetting> PermissionSettings { get; set; }
        public virtual ICollection<Permission> Children { get; set; }
        public virtual ICollection<RecTeam> RecTeams { get; set; }

        public Permission()
        {
            Children = new HashSet<Permission>();
            PermissionSettings = new HashSet<PermissionSetting>();
            RecTeams = new HashSet<RecTeam>();
        }
    }
}
