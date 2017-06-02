using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LMS.Authorization.Users.Dtos;

namespace LMS.Authorization.Users
{
	/// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserAppService : IApplicationService
    {
        #region 用户管理

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<UserListDto>> GetUsersAsync();

        ListResultDto<UserListDto> GetUsers();

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        Task<List<UserListDto>> GetUserList();

        /// <summary>
        /// 根据查询条件获取用户分页列表
        /// </summary>
        Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetUserInput input);

        /// <summary>
        /// 通过Id获取用户信息进行编辑或修改 
        /// </summary>
        Task<GetUserForEditOutput> GetUserForEditAsync(NullableIdDto<Guid> input);

		  /// <summary>
        /// 通过指定id获取用户ListDto信息
        /// </summary>
		Task<UserListDto> GetUserByIdAsync(EntityDto<Guid> input);

        /// <summary>
        /// 新增或更改用户
        /// </summary>
        Task CreateOrUpdateUserAsync(CreateOrUpdateUserInput input);

        /// <summary>
        /// 新增用户
        /// </summary>
        Task<UserEditDto> CreateUserAsync(UserEditDto input);

        /// <summary>
        /// 更新用户
        /// </summary>
        Task UpdateUserAsync(UserEditDto input);

        /// <summary>
        /// 删除用户
        /// </summary>
        Task DeleteUserAsync(EntityDto<Guid> input);

        /// <summary>
        /// 批量删除用户
        /// </summary>
        Task BatchDeleteUserAsync(List<Guid> input);

        #endregion

    }
}
