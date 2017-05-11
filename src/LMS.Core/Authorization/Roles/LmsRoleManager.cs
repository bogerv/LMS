using System;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using LMS.Authorization.Roles;
using Microsoft.AspNet.Identity;

namespace LMS.Authorization.Roles
{
    /// <summary>
    /// 角色业务管理
    /// </summary>
    public class LmsRoleManager : RoleManager<Role, Guid>, IDomainService
    {
        private readonly IRepository<Role, Guid> _roleRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public LmsRoleManager(LmsRoleStore store, IRepository<Role, Guid> roleRepository)
            : base(store)
        {
            _roleRepository = roleRepository;
        }
        public LmsRoleManager(LmsRoleStore store)
            : base(store)
        {
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
