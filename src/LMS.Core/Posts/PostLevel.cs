using Abp.Domain.Values;
using LMS.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Posts
{
    /// <summary>
    /// 职位等级表
    /// </summary>
    public class PostLevel : EntityBase
    {
        public const int MaxPostLevelLength = 256;

        /// <summary>
        /// 职位等级名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 职位等级
        /// </summary>
        public int Level { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public PostLevel(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}
