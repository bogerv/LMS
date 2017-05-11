
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-04-11T14:08:36. All Rights Reserved.
//<生成时间>2017-04-11T14:08:36</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LMS.Authorization.Users;

namespace LMS.Authorization.Users.Dtos
{
	/// <summary>
    /// 用户列表Dto
    /// </summary>
    [AutoMapFrom(typeof(User))]
    public class UserListDto : EntityDto<long>
    {
        public      string UserName { get; set; }
        public      string LocalName { get; set; }
        public      string EmailAddress { get; set; }
        public      DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
