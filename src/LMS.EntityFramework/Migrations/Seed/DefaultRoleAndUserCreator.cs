using System;
using System.Linq;
using Abp.Authorization;
using Abp.MultiTenancy;
using LMS.Authorization.Permissions;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.Authorization.Users.Authorization;
using LMS.EntityFramework;
using LMS.Teams;
using Microsoft.AspNet.Identity;

namespace LMS.Migrations.Seed
{
    public class DefaultRoleAndUserCreator
    {
        private readonly LmsDbContext _context;

        public DefaultRoleAndUserCreator(LmsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            var adminRole = _context.Roles.FirstOrDefault(r => r.Name == StaticRoleNames.Host.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                _context.SaveChanges();

                // todo: 增加User以外所有
                var permissions = PermissionFinder
                    .GetAllPermissions(new UserAuthorizationProvider())
                    .ToList();

                foreach (var permission in permissions)
                {
                    if (!string.IsNullOrEmpty(permission.Name))
                    {
                        _context.PermissionSettings.Add(
                            new PermissionSetting
                            {
                                Name = permission.Name,
                                IsGranted = true,
                                RoleId = adminRole.Id,
                            });
                    }
                }

                _context.SaveChanges();
            }

            var defaultTeam = _context.Teams.FirstOrDefault(t => t.DisplayName == TeamManager.DefaultTeamName);
            if (defaultTeam == null)
            {
                defaultTeam = new Team { DisplayName = TeamManager.DefaultTeamName, Code = "0000.0000.0000", ParentId = Guid.Empty };
                _context.Teams.Add(defaultTeam);
                _context.SaveChanges();
            }

            var adminUser = _context.Users.FirstOrDefault(u => u.UserName == User.AdminUserName);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = User.AdminUserName,
                    Name = "admin",
                    Surname = "Administrator",
                    EmailAddress = "admin@aspnetboilerplate.com",
                    IsEmailConfirmed = true,
                    Password = new PasswordHasher().HashPassword("Mit000"),
                    TeamId = defaultTeam.Id
                };

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }
        }
    }
}
