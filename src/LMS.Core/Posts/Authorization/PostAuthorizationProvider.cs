using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using LMS.Authorization;

namespace LMS.Posts.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// </summary>
    public class PostAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Post 的权限。
            var pages = context.GetPermissionOrNull(LmsPermissions.Pages) ?? context.CreatePermission(LmsPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == LmsPermissions.Pages_Administration)
               ?? pages.CreateChildPermission(LmsPermissions.Pages_Administration, L("Administration"));

            var Post = entityNameModel.CreateChildPermission(PostPermissions.Post, L("Post"));
            Post.CreateChildPermission(PostPermissions.Post_CreatePost, L("CreatePost"));
            Post.CreateChildPermission(PostPermissions.Post_EditPost, L("EditPost"));
            Post.CreateChildPermission(PostPermissions.Post_DeletePost, L("DeletePost"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LmsConsts.LocalizationSourceName);
        }
    }
}