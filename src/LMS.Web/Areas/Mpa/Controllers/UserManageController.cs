using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using LMS.Authorization.Users;
using LMS.Authorization.Users.Authorization;
using LMS.Authorization.Users.Dtos;
using LMS.Web.Areas.Mpa.Models.User;
using LMS.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LMS.Web.Areas.Mpa.Controllers
{
    public class UserManageController : LMSControllerBase
    {

        private readonly IUserAppService _userAppService;

        public UserManageController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public ActionResult Index()
        {
            var model = new GetUserInput { FilterText = Request.QueryString["filterText"] };
            return View(model);
        }

        /// <summary>
        ///     根据id获取进行编辑或者添加的用户信息
        /// </summary>
        ///  <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(UserAppPermissions.User_CreateUser, UserAppPermissions.User_EditUser)]
        public async Task<ActionResult> CreateOrEditUserModal(Guid? id)
        {

            var input = new NullableIdDto<Guid> { Id = id };

            var output = await _userAppService.GetUserForEditAsync(input);

            var viewModel = new CreateOrEditUserModalViewModel(output);

            return View(viewModel);

        }
    }
}