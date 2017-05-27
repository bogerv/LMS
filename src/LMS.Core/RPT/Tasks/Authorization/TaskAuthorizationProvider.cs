using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using LMS.Authorization;

namespace LMS.RPT.Tasks.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// </summary>
    public class TaskAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Task 的权限。
            var pages = context.GetPermissionOrNull(LmsPermissions.Pages) ?? context.CreatePermission(LmsPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LmsPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LmsPermissions.Pages_Administration, L("Administration"));

            var Task = entityNameModel.CreateChildPermission(TaskPermissions.Task, L("Task"));
            Task.CreateChildPermission(TaskPermissions.Task_CreateTask, L("CreateTask"));
            Task.CreateChildPermission(TaskPermissions.Task_EditTask, L("EditTask"));
            Task.CreateChildPermission(TaskPermissions.Task_DeleteTask, L("DeleteTask"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}