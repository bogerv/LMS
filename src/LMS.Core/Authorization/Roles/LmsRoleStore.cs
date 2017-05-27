using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using LMS.Authorization.Permissions;
using LMS.Authorization.Users;

namespace LMS.Authorization.Roles
{
    public class LmsRoleStore : ITransientDependency
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public LmsRoleStore(
             IRepository<Role,Guid> roleRepository,
             IRepository<UserRole, Guid> userRoleRepository,
             IRepository<PermissionSetting, Guid> rolePermissionSettingRepository)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _rolePermissionSettingRepository = rolePermissionSettingRepository;
        }

        private readonly IRepository<Role, Guid> _roleRepository;
        private readonly IRepository<UserRole, Guid> _userRoleRepository;
        private readonly IRepository<PermissionSetting, Guid> _rolePermissionSettingRepository;


        public void Dispose()
        {
        }

        public virtual IQueryable<Role> Roles => _roleRepository.GetAll();

        public virtual async Task CreateAsync(Role role)
        {
            await _roleRepository.InsertAsync(role);
        }

        public virtual async Task UpdateAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        public virtual async Task DeleteAsync(Role role)
        {
            await _userRoleRepository.DeleteAsync(ur => ur.RoleId == role.Id);
            await _roleRepository.DeleteAsync(role);
        }

        public virtual async Task<Role> FindByIdAsync(Guid roleId)
        {
            return await _roleRepository.FirstOrDefaultAsync(roleId);
        }

        public virtual async Task<Role> FindByNameAsync(string roleName)
        {
            return await _roleRepository.FirstOrDefaultAsync(
                role => role.Name == roleName
                );
        }

        public virtual async Task<Role> FindByDisplayNameAsync(string displayName)
        {
            return await _roleRepository.FirstOrDefaultAsync(
                role => role.DisplayName == displayName
                );
        }
    }
}
