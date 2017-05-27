using System;
using System.Collections.Generic;
using LMS.Teams;
using Abp.Domain.Entities;
using LMS.RecTeams;
using Abp.Domain.Entities.Auditing;
using LMS.Authorization.Permissions;
using Microsoft.AspNet.Identity;

namespace LMS.Authorization.Users
{
    public class User : Entity<Guid>, IUser<Guid>, IPassivable, IHasCreationTime, IHasModificationTime, IHasDeletionTime
    {
        public const string DefaultPassword = "000000";
        public const int MaxUserNameLength = 64;

        public const int MaxPasswordLength = 256;
        public const int MaxEmailAddressLength = 256;
        public const string AdminUserName = "Admin";

        /// <summary>登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>姓氏
        /// </summary>
        public string Surname { get; set; }
        /// <summary>密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>邮件地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>是否验证邮件地址
        /// </summary>
        public bool IsEmailConfirmed { get; set; }
        /// <summary>
        /// 重置密码校验码
        /// </summary>
        public string PasswordResetCode { get; set; }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public uint? Gender { get; set; }
        /// <summary>
        /// 用户头像文件名
        /// </summary>
        public string ProfilePicture { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        #region Audited
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; } 
        #endregion

        #region 导航属性
        public virtual Guid? CreatorUserId { get; set; }
        public virtual Guid? DeleterUserId { get; set; }
        public virtual Guid? LastModifierUserId { get; set; }
        public virtual User DeleterUser { get; set; }
        public virtual User CreatorUser { get; set; }
        public virtual User LastModifierUser { get; set; }
        public virtual Guid TeamId { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<UserPost> UserPosts { get; set; } = new HashSet<UserPost>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public virtual ICollection<RecTeam> RecTeams { get; set; } = new HashSet<RecTeam>();
        public virtual ICollection<PermissionSetting> PermissionSettings { get; set; } = new HashSet<PermissionSetting>();

        #endregion
    }
}
