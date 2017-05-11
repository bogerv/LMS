using LMS.Base;
using LMS.Teams;
using LMS.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LMS.RecTeams;
using System;

namespace LMS.Posts
{
    /// <summary>
    /// 职位
    /// </summary>
    public class Post : EntityBase
    {
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 职位描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Team的Id
        /// </summary>
        public virtual Guid? TeamId { get; set; }
        /// <summary>
        /// PostLevel的Id
        /// </summary>
        public virtual Guid? PostLevelId { get; set; }

        #region 导航属性
        public virtual Team Team { get; set; }
        public virtual PostLevel PostLevel { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
        public virtual ICollection<RecTeam> RecTeams { get; set; }
        #endregion

        public Post()
        {
            UserPosts = new HashSet<UserPost>();
            RecTeams = new HashSet<RecTeam>();
        }
    }
}
