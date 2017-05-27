using System;
using Abp.Domain.Entities;

namespace LMS.Base
{
    public interface ICreationAudited : IHasCreationTime
    {
        /// <summary>
        /// ������ʵ���û�Id.
        /// </summary>
        Guid? CreatorUserId { get; set; }
    }

    /// <summary>
    /// Ϊ�ӿ� <see cref="ICreationAudited"/> ��� User ��������.
    /// </summary>
    /// <typeparam name="TUser">User����</typeparam>
    public interface ICreationAudited<TUser> : ICreationAudited
        where TUser : IEntity<Guid>
    {
        /// <summary>
        /// ��������.
        /// </summary>
        TUser CreatorUser { get; set; }
    }
}