using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Authorization.Permissions
{
    public class PermissionSetting : CreationAuditedEntity<Guid>, IMayHaveTenant
    {
        public const int MaxNameLength = 128;

        public bool IsGranted { get; set; }
        public virtual Guid PermissionId { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual Guid UserId { get; set; }

        public int? TenantId { get; set; }

        public PermissionSetting()
        {
            IsGranted = true;
        }
    }
}
