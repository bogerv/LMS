﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using LMS.Authorization.Users.Authorization;
using LMS.Authorization.Users.Dtos;

namespace LMS.Authorization.Users
{
    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class UserAppService : LmsAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IPermissionManager _permissionManager;
        private readonly LmsUserManager _userManager;

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserAppService(IRepository<User, Guid> userRepository, LmsUserManager userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        #region 用户管理

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<UserListDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllListAsync();

            return new ListResultDto<UserListDto>(
                users.MapTo<List<UserListDto>>()
            );
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public ListResultDto<UserListDto> GetUsers()
        {
            if (!PermissionChecker.IsGranted(UserPermissions.User))
            {
                throw new AbpAuthorizationException("You are not authorized to create user!");
            }

            var users = _userRepository.GetAll();

            return new ListResultDto<UserListDto>(
                users.MapTo<List<UserListDto>>()
            );
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserListDto>> GetUserList()
        {
            var users = await _userRepository.GetAllListAsync();

            return users.MapTo<List<UserListDto>>();
        }

        /// <summary>
        /// 根据查询条件获取用户分页列表
        /// </summary>
        public async Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetUserInput input)
        {
            var query = _userRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var userCount = await query.CountAsync();

            var users = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var userListDtos = users.MapTo<List<UserListDto>>();
            return new PagedResultDto<UserListDto>(
                userCount,
                userListDtos
            );
        }

        /// <summary>
        /// 通过Id获取用户信息进行编辑或修改 
        /// </summary>
        public async Task<GetUserForEditOutput> GetUserForEditAsync(NullableIdDto<Guid> input)
        {
            var output = new GetUserForEditOutput();

            UserEditDto userEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _userRepository.GetAsync(input.Id.Value);
                userEditDto = entity.MapTo<UserEditDto>();
            }
            else
            {
                userEditDto = new UserEditDto();
            }

            output.User = userEditDto;
            return output;
        }

        /// <summary>
        /// 通过指定id获取用户ListDto信息
        /// </summary>
        public async Task<UserListDto> GetUserByIdAsync(EntityDto<Guid> input)
        {
            var entity = await _userRepository.GetAsync(input.Id);

            return entity.MapTo<UserListDto>();
        }

        /// <summary>
        /// 新增或更改用户
        /// </summary>
        public async Task CreateOrUpdateUserAsync(CreateOrUpdateUserInput input)
        {
            if (input.UserEditDto.Id.HasValue)
            {
                await UpdateUserAsync(input.UserEditDto);
            }
            else
            {
                await CreateUserAsync(input.UserEditDto);
            }
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        [AbpAuthorize(UserPermissions.User_CreateUser)]
        public virtual async Task<UserEditDto> CreateUserAsync(UserEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<User>();

            entity = await _userRepository.InsertAsync(entity);
            return entity.MapTo<UserEditDto>();
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        [AbpAuthorize(UserPermissions.User_EditUser)]
        public virtual async Task UpdateUserAsync(UserEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            Debug.Assert(input.Id != null, "input.Id != null");
            var entity = await _userRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _userRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        [AbpAuthorize(UserPermissions.User_DeleteUser)]
        public async Task DeleteUserAsync(EntityDto<Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _userRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除用户
        /// </summary>
        [AbpAuthorize(UserPermissions.User_DeleteUser)]
        public async Task BatchDeleteUserAsync(List<Guid> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _userRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion

    }
}
