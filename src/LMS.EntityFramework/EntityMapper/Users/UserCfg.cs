using LMS.Authorization.Users;
using System.Data.Entity.ModelConfiguration;
using LMS.EntityFramework;

namespace LMS.EntityMapper
{
    /// <summary>
    /// 用户的数据配置文件
    /// </summary>
    public class UserCfg : EntityTypeConfiguration<User>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "LmsDbContext" /> ]
        /// </summary>
        public UserCfg()
        {
            ToTable("User", LmsConsts.SchemaName.Basic);

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
                .IsOptional()
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

            Property(u => u.CreatorUserId).IsOptional();

            Property(u => u.LastModifierUserId).IsOptional();

            Property(u => u.DeleterUserId).IsOptional();

            //HasOptional(u => u.DeleterUser)
            //    .WithMany()
            //    .HasForeignKey(u => u.DeleterUserId);

            //HasOptional(u => u.CreatorUser)
            //    .WithMany()
            //    .HasForeignKey(u => u.CreatorUserId);

            //HasOptional(u => u.LastModifierUser)
            //    .WithMany()
            //    .HasForeignKey(u => u.LastModifierUserId);

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

            // DeleterUser - 关系映射
            HasOptional(a => a.DeleterUser).WithMany().HasForeignKey(c => c.DeleterUserId).WillCascadeOnDelete(false);
            // CreatorUser - 关系映射
            HasOptional(a => a.CreatorUser).WithMany().HasForeignKey(c => c.CreatorUserId).WillCascadeOnDelete(false);
            // LastModifierUser - 关系映射
            HasOptional(a => a.LastModifierUser).WithMany().HasForeignKey(c => c.LastModifierUserId).WillCascadeOnDelete(false);
        }
    }
}