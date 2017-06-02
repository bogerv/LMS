using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using LMS.Attributes;
using LMS.Authorization.Users;
using LMS.Authorization.Users.Authorization;
using LMS.Authorization.Users.Dtos;
using LMS.Datatables;
using LMS.Web.Controllers;

namespace LMS.Web.Areas.Mpa.Controllers
{
    //[AbpMvcAuthorize(UserPermissions.User)]
    [LmsMvcAuthorize]
    public class UserController : LmsControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// User 页面加载
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (!PermissionChecker.IsGranted(UserPermissions.User))
            {
                throw new AbpAuthorizationException("You are not authorized to create user!");
            }

            var output = _userAppService.GetUsers();

            return View(output);
        }

        /// <summary>
        /// 获取 User List
        /// </summary>
        /// <returns></returns>
        [DontWrapResult]
        public async Task<JsonResult> List(int start, int length)
        {
            var output = await _userAppService.GetUserList();
            var count = output.Count;
            output = output.Skip(start).Take(length).ToList();

            return Json(new DatatablesResultDto<UserListDto>() {
                recordsTotal = count,
                recordsFiltered = count,
                data=output
            });
        }

        /// <summary>
        /// User 编辑页面
        /// </summary>
        /// <param name="input">用户 Id</param>
        /// <returns></returns>
        public async Task<ActionResult> CreateOrEditModal(Guid id)
        {
            var user = await _userAppService.GetUserByIdAsync(new EntityDto<Guid> { Id = id});

            return PartialView("_CreateOrEditModal", user);
            //return View("EidtModal",user);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="input">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        [AbpMvcAuthorize(UserPermissions.User_CreateUser)]
        public async Task CreateUser(CreateOrUpdateUserInput input)
        {
            await _userAppService.CreateOrUpdateUserAsync(input);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInput">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        //[AbpMvcAuthorize(PermissionNames.Pages_Administration_Users_Edit)]
        public async Task<JsonResult> Update(CreateOrUpdateUserInput userInput)
        {
            await _userAppService.CreateOrUpdateUserAsync(userInput);

            return Json("");
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userInput">用户Id</param>
        /// <returns></returns>
        [HttpPost]
        //[AbpMvcAuthorize(PermissionNames.Pages_Administration_Users_Delete)]
        public async Task<JsonResult> Delete(EntityDto<Guid> input)
        {
            await _userAppService.DeleteUserAsync(input);

            return Json("");
        }
    }
}