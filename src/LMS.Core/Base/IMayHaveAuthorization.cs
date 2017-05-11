using Abp.Domain.Entities;
using System;

namespace LMS.Entities
{
    public interface IAuthorizationAudited
    {
        long? AuthenticaterUserId { get; set; }
    }

    public interface IHasAuthorizationTime
    {
        /// <summary>授权时间
        /// </summary>
        DateTime? AuthorizationTime { get; set; }
    }
    
    public interface IAuthorizationAudited<TUser> : IHasAuthorizationTime where TUser : IEntity<long>
    {
        /// <summary>授权人
        /// </summary>
        TUser AuthenticaterUser { get; set; }
    }
}
