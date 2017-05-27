namespace LMS.Posts.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// </summary>
    public static class PostPermissions
    {
        /// <summary>
        /// 用户管理权限
        /// </summary>
        public const string Post = "Pages.Administration.Post";
        /// <summary>
        /// 用户创建权限
        /// </summary>
        public const string Post_CreatePost = "Pages.Administration.Post.CreatePost";
        /// <summary>
        /// 用户修改权限
        /// </summary>
        public const string Post_EditPost = "Pages.Administration.Post.EditPost";
        /// <summary>
        /// 用户删除权限
        /// </summary>
        public const string Post_DeletePost = "Pages.Administration.Post.DeletePost";
    }
}

