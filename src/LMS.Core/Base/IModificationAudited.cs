using System;
using Abp.Domain.Entities;

namespace LMS.Base
{
    public interface IModificationAudited : IHasModificationTime
    {
        /// <summary>
        /// 最后更新人 Id.
        /// </summary>
        Guid? LastModifierUserId { get; set; }
    }

    /// <summary>
    /// 为接口 <see cref="IModificationAudited"/> 添加 User 的导航属性.
    /// </summary>
    /// <typeparam name="TUser">User 类型</typeparam>
    public interface IModificationAudited<TUser> : IModificationAudited
        where TUser : IEntity<Guid>
    {
        /// <summary>
        /// 导航属性.
        /// </summary>
        TUser LastModifierUser { get; set; }
    }
}