using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.Components.DictionaryAdapter;
using LMS.Entities;
using LMS.Posts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Authorization.Users
{
    public class UserPost : CreationAuditedEntity<Guid>, IMayHaveTenant, IPassivable
    {
        public int? TenantId { get; set; }

        public bool? IsMain { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        #region 导航属性
        public virtual Guid UserId { get; set; }
        public virtual Guid PostId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        #endregion

        /// <summary>职位状态
        /// 0: NotQualified
        /// 1: Qualified
        /// </summary>
        public int? PostStatus { get; set; }

        public UserPost()
        {
        }

        public UserPost(int? tenantId, Guid userId, Guid postId)
        {
            TenantId = tenantId;
            UserId = userId;
            PostId = postId;
            IsActive = true;
        }
    }
}
