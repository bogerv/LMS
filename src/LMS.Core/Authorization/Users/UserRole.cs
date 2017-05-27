using LMS.Base;
using System;

namespace LMS.Authorization.Users
{
    public class UserRole : CreationAuditedEntity<Guid>
    {
        public virtual Guid UserId { get; set; }
        public virtual Guid RoleId { get; set; }

        public UserRole()
        {
        }

        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
