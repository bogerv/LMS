using System;
using Abp.Domain.Entities;

namespace LMS.Base
{
    public interface IModificationAudited : IHasModificationTime
    {
        /// <summary>
        /// �������� Id.
        /// </summary>
        Guid? LastModifierUserId { get; set; }
    }

    /// <summary>
    /// Ϊ�ӿ� <see cref="IModificationAudited"/> ��� User �ĵ�������.
    /// </summary>
    /// <typeparam name="TUser">User ����</typeparam>
    public interface IModificationAudited<TUser> : IModificationAudited
        where TUser : IEntity<Guid>
    {
        /// <summary>
        /// ��������.
        /// </summary>
        TUser LastModifierUser { get; set; }
    }
}