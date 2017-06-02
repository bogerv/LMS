using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace LMS.Roles
{
    /// <summary>
    /// 角色操作接口
    /// </summary>
    public interface IRoleAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<RoleListDto>> GetRoles();

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        Task<GetRoleForEditOutput> GetRoleForEdit(NullableIdDto<int> input);

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEditRole(CreateOrEditRoleInput input);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        Task<List<RoleListDto>> GetRoleList();

        /// <summary>
        /// 删除角色
        /// </summary>
        Task DeleteRole(EntityDto input);
    }
}
