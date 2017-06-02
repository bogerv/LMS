using Abp.AutoMapper;
using LMS.Roles;
using LMS.Web.Areas.Mpa.Models.Permissions;

namespace LMS.Web.Areas.Mpa.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}