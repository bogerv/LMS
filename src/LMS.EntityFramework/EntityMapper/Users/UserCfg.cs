using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using System.Data.Entity.ModelConfiguration;

namespace LMS.EntityMapper
{
    /// <summary>
    /// 用户的数据配置文件
    /// </summary>
    public class UserCfg : EntityTypeConfiguration<User>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "LMSDbContext" /> ]
        /// </summary>
        public UserCfg()
        {
            ToTable("User", LMSConsts.SchemaName.Basic);

            // UserName
            Property(a => a.UserName)
                .IsRequired()
                .HasMaxLength(User.MaxUserNameLength);

            // Name
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(User.MaxUserNameLength);

            // Surname
            Property(a => a.Surname)
                .IsRequired()
                .HasMaxLength(User.MaxUserNameLength);

            // Password
            Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(User.MaxPasswordLength);

            // EmailAddress
            Property(a => a.EmailAddress)
                .IsRequired()
                .HasMaxLength(User.MaxEmailAddressLength);

            // TeamId
            Property(a => a.TeamId)
                .IsRequired();

            HasRequired(u => u.DeleterUser)
                .WithMany()
                .HasForeignKey(u => u.DeleterUserId);

            HasRequired(u => u.CreatorUser)
                .WithMany()
                .HasForeignKey(u => u.CreatorUserId);

            HasRequired(u => u.LastModifierUser)
                .WithMany()
                .HasForeignKey(u => u.LastModifierUserId);

            HasMany(u => u.RecTeams)
                .WithOptional()
                .HasForeignKey(t => t.TableId).WillCascadeOnDelete(false);

            HasMany(u => u.UserPosts)
                .WithOptional()
                .HasForeignKey(up => up.UserId).WillCascadeOnDelete(false);

            HasMany(u => u.UserRoles)
                .WithOptional()
                .HasForeignKey(ur => ur.UserId).WillCascadeOnDelete(false);

            HasMany(u => u.PermissionSettings)
                .WithOptional()
                .HasForeignKey(ps => ps.UserId).WillCascadeOnDelete(false);

            // UserRole Map
            //HasMany(u => u.Roles).WithMany(r => r.Users).Map(m => {
            //    m.MapLeftKey("UserId");
            //    m.MapRightKey("RoleId");
            //    m.ToTable("UserRole");
            //});

            //// DeleterUser - 关系映射
            //HasRequired(a => a.DeleterUser).WithMany().HasForeignKey(c => c.DeleterUserId).WillCascadeOnDelete(true);
            //// CreatorUser - 关系映射
            //HasRequired(a => a.CreatorUser).WithMany().HasForeignKey(c => c.CreatorUserId).WillCascadeOnDelete(true);
            //// LastModifierUser - 关系映射
            //HasRequired(a => a.LastModifierUser).WithMany().HasForeignKey(c => c.LastModifierUserId).WillCascadeOnDelete(true);
        }
    }
}