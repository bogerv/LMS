using Abp.Domain.Entities;
using System;

namespace LMS.Base
{
    public interface IAuthorizationAudited
    {
        /// <summary>
        /// 授权人
        /// </summary>
        long? AuthenticaterUserId { get; set; }
    }

    public interface IHasAuthorizationTime
    {
        /// <summary>授权时间
        /// </summary>
        DateTime? AuthorizationTime { get; set; }
    }
    
    public interface IAuthorizationAudited<TUser> : IHasAuthorizationTime, IAuthorizationAudited where TUser : IEntity<long>
    {
        /// <summary>授权人
        /// </summary>
        TUser AuthenticaterUser { get; set; }
    }
}
