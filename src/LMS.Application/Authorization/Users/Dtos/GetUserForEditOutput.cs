﻿// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-04-11T14:08:36. All Rights Reserved.
//<生成时间>2017-04-11T14:08:36</生成时间>
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using LMS.Authorization.Users;

namespace LMS.Authorization.Users.Dtos
{
	/// <summary>
    /// 用于添加或编辑 用户时使用的DTO
    /// </summary>
  
    public class GetUserForEditOutput 
    {
 

	      /// <summary>
         /// User编辑状态的DTO
        /// </summary>
    public UserEditDto User{get;set;}


    }
}
