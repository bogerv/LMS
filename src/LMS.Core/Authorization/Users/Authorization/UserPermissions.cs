namespace LMS.Authorization.Users.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="UserAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class UserPermissions
    {
        /// <summary>
        /// 用户管理权限
        /// </summary>
        public const string User = "Pages.Administration.User";
        /// <summary>
        /// 用户创建权限
        /// </summary>
        public const string User_CreateUser = "Pages.Administration.User.CreateUser";
        /// <summary>
        /// 用户修改权限
        /// </summary>
        public const string User_EditUser = "Pages.Administration.User.EditUser";
        /// <summary>
        /// 用户删除权限
        /// </summary>
        public const string User_DeleteUser = "Pages.Administration.User.DeleteUser";
    }
}

