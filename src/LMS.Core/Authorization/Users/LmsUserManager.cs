using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.AspNet.Identity;
using System;

namespace LMS.Authorization.Users
{
    /// <summary>
    /// 用户业务管理
    /// </summary>
    public class LmsUserManager : UserManager<User,Guid>, IDomainService
    {
        private readonly IRepository<User, Guid> _userRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public LmsUserManager(LmsUserStore store, IRepository<User, Guid> userRepository)
            : base(store)
        {
            _userRepository = userRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {

        }
    }
}
