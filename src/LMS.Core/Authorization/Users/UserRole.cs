using Abp.Domain.Entities;
using System;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using LMS.Authorization.Roles;

namespace LMS.Authorization.Users
{
    public class UserRole : Entity<Guid>, IHasCreationTime, IMayHaveTenant
    {
        public virtual Guid UserId { get; set; }
        public virtual Guid RoleId { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual Guid CreatorUserId { get; set; }
        public int? TenantId { get; set; }

        public UserRole()
        {
        }

        public UserRole(int? tenantId, Guid userId, Guid roleId)
        {
            TenantId = tenantId;
            UserId = userId;
            RoleId = roleId;
        }
    }
}
