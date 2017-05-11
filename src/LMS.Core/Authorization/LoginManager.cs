using System;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using LMS.Authorization.Roles;

namespace LMS.Authorization
{
    /// <summary>
    /// 角色业务管理
    /// </summary>
    public class LoginManager : IDomainService
    {
        private readonly IRepository<Role, Guid> _roleRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public LoginManager(IRepository<Role, Guid> roleRepository)
        {
            _roleRepository = roleRepository;
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
