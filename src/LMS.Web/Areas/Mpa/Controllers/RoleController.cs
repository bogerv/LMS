using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using LMS.Authorization.Roles.Authorization;
using LMS.Datatables;
using LMS.Roles;
using LMS.Web.Areas.Mpa.Models.Roles;
using LMS.Web.Controllers;

namespace LMS.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(RolePermissions.Role)]
    public class RoleController : LmsControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RoleController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _roleAppService.GetRoles();

            return View(output);
        }

        [AbpMvcAuthorize(RolePermissions.Role_CreateRole, RolePermissions.Role_EditRole)]
        public async Task<ActionResult> CreateOrEditRole(int? id)
        {
            var role = await _roleAppService.GetRoleForEdit(new NullableIdDto<int> { Id = id });
            var viewModel = new CreateOrEditRoleViewModel(role);

            return View("_CreateOrEditModal", viewModel);
        }

        /// <summary>
        /// 获取 User List
        /// </summary>
        /// <returns></returns>
        [DontWrapResult]
        public async Task<JsonResult> List(int start, int length)
        {
            var output = await _roleAppService.GetRoleList();
            var count = output.Count;
            output = output.Skip(start).Take(length).ToList();

            return Json(new DatatablesResultDto<RoleListDto>()
            {
                recordsTotal = count,
                recordsFiltered = count,
                data = output
            });
        }
    }
}