using System;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using LMS.Authorization.Roles;
using Abp.Domain.Uow;
using LMS.Authorization.Users;
using Abp.Configuration;
using Abp.Dependency;

namespace LMS.Authorization
{
    /// <summary>
    /// 角色业务管理
    /// </summary>
    public class LoginManager : IDomainService
    {
        private readonly IRepository<Role, Guid> _roleRepository;
        protected IUnitOfWorkManager UnitOfWorkManager { get; }
        protected LmsUserManager UserManager { get; }
        protected ISettingManager SettingManager { get; }
        protected IIocResolver IocResolver { get; }
        protected LmsRoleManager RoleManager { get; }

        protected LoginManager(
           LmsUserManager userManager,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IIocResolver iocResolver,
            LmsRoleManager roleManager)
        {
            UnitOfWorkManager = unitOfWorkManager;
            SettingManager = settingManager;
            IocResolver = iocResolver;
            RoleManager = roleManager;
            UserManager = userManager;
        }

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
