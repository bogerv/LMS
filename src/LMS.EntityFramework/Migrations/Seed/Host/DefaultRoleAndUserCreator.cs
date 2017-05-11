using LMS.Authorization.Permissions;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Migrations.Seed.Host
{
    public class DefaultRoleAndUserCreator
    {
        private readonly LMSDbContext _context;

        public DefaultRoleAndUserCreator(LMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            // 管理员角色
            var adminRoleForHost = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.Admin, StaticRoleNames.Host.Admin) { IsStatic = true, IsDefault = false });
            }

            // 管理员用户
            var adminUserForHost = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == User.AdminUserName);
            if (adminUserForHost == null)
            {
                adminUserForHost = _context.Users.Add(new User {
                    TenantId = null,
                    UserName = User.AdminUserName,
                    Name = "admin",
                    Surname = "admin",
                    EmailAddress = "bogerv@163.com",
                    IsEmailConfirmed = true,
                    IsActive = true,
                    Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                });

                _context.SaveChanges();

                // 为管理员用户分配管理员角色
                _context.UserRoles.Add(new UserRole(null,adminUserForHost.Id,adminRoleForHost.Id));
                _context.SaveChanges();

                // 初始化权限

                // 分配权限
                var permissions = _context.Permissions.ToList();
                foreach (var permission in permissions)
                {
                    _context.PermissionSettings.Add(
                        new PermissionSetting {
                            TenantId = null,
                            PermissionId = permission.Id,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }
                _context.SaveChanges();
            }
        }
    }
}
