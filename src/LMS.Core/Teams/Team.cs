using LMS.Base;
using LMS.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using LMS.Posts;
using System;

namespace LMS.Teams
{
    public class Team : EntityBase
    {
        /// <summary>
        /// 最大显示名长度
        /// </summary>
        public const int MaxDisplayNameLength = 256;
        /// <summary>
        /// 最大层次
        /// </summary>
        public const int MaxDepth = 16;
        /// <summary>
        /// 点之间的代码单元的长度
        /// </summary>
        public const int CodeUnitLength = 5;
        /// <summary>
        /// Code最大长度
        /// </summary>
        public const int MaxCodeLength = MaxDepth * (CodeUnitLength + 1) - 1;
        
        /// <summary>
        /// Team的分层校验码.
        /// 例如: "00001.00042.00005".
        /// 对于租户来说是唯一的.
        /// 当分层改变时,此字段也要变动.
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// Team显示名称
        /// </summary>
        public string DisplayName { get; set; }

        #region 导航属性
        /// <summary>
        /// 父级Id
        /// </summary>
        public Guid ParentId { get; set; }
        public virtual Team Parent { get; set; }

        public virtual ICollection<Team> Children { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        #endregion

        public Team()
        {
            Children = new HashSet<Team>();
            Users = new HashSet<User>();
            Posts = new HashSet<Post>();
        }
    }
}
