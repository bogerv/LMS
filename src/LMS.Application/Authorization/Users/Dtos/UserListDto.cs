using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace LMS.Authorization.Users.Dtos
{
    /// <summary>
    /// 用户列表Dto
    /// </summary>
    [AutoMapFrom(typeof(User))]
    public class UserListDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
        public string LocalName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
