using System;
using Abp.Domain.Entities;

namespace LMS.Base
{
    public interface ICreationAudited : IHasCreationTime
    {
        /// <summary>
        /// 创建此实体用户Id.
        /// </summary>
        Guid? CreatorUserId { get; set; }
    }

    /// <summary>
    /// 为接口 <see cref="ICreationAudited"/> 添加 User 导航属性.
    /// </summary>
    /// <typeparam name="TUser">User类型</typeparam>
    public interface ICreationAudited<TUser> : ICreationAudited
        where TUser : IEntity<Guid>
    {
        /// <summary>
        /// 导航属性.
        /// </summary>
        TUser CreatorUser { get; set; }
    }
}