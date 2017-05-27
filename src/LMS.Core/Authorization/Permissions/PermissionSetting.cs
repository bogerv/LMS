using LMS.Base;
using System;

namespace LMS.Authorization.Permissions
{
    public class PermissionSetting : CreationAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;

        public bool IsGranted { get; set; }
        public virtual string Name { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual Guid? UserId { get; set; }

        public PermissionSetting()
        {
            IsGranted = true;
        }
    }
}
