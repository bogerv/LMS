using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using LMS.Authorization.Permissions;
using LMS.Authorization.Roles;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Authorization.Users
{
    public class LmsUserStore : IUserStore<User, Guid>, IUserPasswordStore<User,Guid>, ITransientDependency
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public LmsUserStore(
            IRepository<User, Guid> userRepository,
            //IRepository<UserLogin, Guid> userLoginRepository,
            IRepository<UserRole, Guid> userRoleRepository,
            IRepository<Role, Guid> roleRepository,
            IRepository<PermissionSetting, Guid> userPermissionSettingRepository,
            IUnitOfWorkManager unitOfWorkManager
            //,IRepository<UserClaim, Guid> userClaimRepository
            )
        {
            _userRepository = userRepository;
            //_userLoginRepository = userLoginRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _unitOfWorkManager = unitOfWorkManager;
            //_userClaimRepository = userClaimRepository;
            _userPermissionSettingRepository = userPermissionSettingRepository;

            //AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        private readonly IRepository<User, Guid> _userRepository;
        //private readonly IRepository<UserLogin, Guid> _userLoginRepository;
        private readonly IRepository<UserRole, Guid> _userRoleRepository;
        //private readonly IRepository<UserClaim, Guid> _userClaimRepository;
        private readonly IRepository<Role, Guid> _roleRepository;
        private readonly IRepository<PermissionSetting, Guid> _userPermissionSettingRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public async Task CreateAsync(User user)
        {
            await _userRepository.InsertAsync(user);
        }

        public virtual async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public virtual async Task DeleteAsync(User user)
        {
            await _userRepository.DeleteAsync(user.Id);
        }

        public virtual async Task<User> FindByIdAsync(Guid userId)
        {
            return await _userRepository.FirstOrDefaultAsync(userId);
        }

        public virtual async Task<User> FindByNameAsync(string userName)
        {
            return await _userRepository.FirstOrDefaultAsync(
                user => user.UserName == userName
            );
        }

        public virtual async Task<User> FindByEmailAsync(string email)
        {
            return await _userRepository.FirstOrDefaultAsync(
                user => user.EmailAddress == email
            );
        }

        public void Dispose()
        {
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult<string>(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult<bool>(!String.IsNullOrEmpty(user.Password));
        }

        public Task<User> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
