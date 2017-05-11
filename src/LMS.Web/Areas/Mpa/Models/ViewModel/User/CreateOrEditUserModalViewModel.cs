using Abp.AutoMapper;
using LMS.Authorization.Users.Dtos;

namespace LMS.Web.Areas.Mpa.Models.User
{
    /// <summary>
    /// 新建或编辑用户时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetUserForEditOutput))]
    public class CreateOrEditUserModalViewModel : GetUserForEditOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
        public CreateOrEditUserModalViewModel(GetUserForEditOutput output)
        {
            output.MapTo(this);
        }

        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return User.Id.HasValue; } }

        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }
    }
}
