using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LMS.Authorization.Permissions;
using LMS.Authorization.Users;
using LMS.RecTeams;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace LMS.Authorization.Roles
{
    public class Role : Entity<Guid>, IHasCreationTime, IHasModificationTime, IHasDeletionTime, ISoftDelete, IMayHaveTenant, IRole<Guid>
    {
        public const int MaxNameLength = 256;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色显示名称
        /// </summary>
        public string DisplayName { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 是否系统制定(不可以删除的角色)
        /// </summary>
        public bool IsStatic { get; set; }
        /// <summary>
        /// 是否是默认角色
        /// </summary>
        public bool IsDefault { get; set; }
        public virtual int? TenantId { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public virtual Guid CreatorUserId { get; set; }
        public virtual Guid DeleterUserId { get; set; }
        public virtual Guid LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RecTeam> RecTeams { get; set; }
        public virtual ICollection<PermissionSetting> PermissionSettings { get; set; }

        public Role()
        {
            UserRoles = new HashSet<UserRole>();
            RecTeams = new HashSet<RecTeam>();
            PermissionSettings = new HashSet<PermissionSetting>();
        }

        public Role(int? tenantId, string displayName)
        {
            TenantId = tenantId;
            DisplayName = displayName;
            UserRoles = new HashSet<UserRole>();
            RecTeams = new HashSet<RecTeam>();
            PermissionSettings = new HashSet<PermissionSetting>();
        }

        public Role(int? tenantId, string name, string displayName)
        {
            TenantId = tenantId;
            Name = name;
            DisplayName = displayName;
            UserRoles = new HashSet<UserRole>();
            RecTeams = new HashSet<RecTeam>();
            PermissionSettings = new HashSet<PermissionSetting>();
        }
    }
}
