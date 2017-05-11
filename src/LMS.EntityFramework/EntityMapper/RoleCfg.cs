using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using LMS.Authorization.Roles;

namespace LMS.EntityMapper
{
    public class RoleCfg : EntityTypeConfiguration<Role>
    {
        public RoleCfg()
        {
            ToTable("Role");

            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(Role.MaxNameLength);

            HasMany(r => r.UserRoles)
                .WithOptional()
                .HasForeignKey(ur => ur.RoleId).WillCascadeOnDelete(false);

            HasMany(r=>r.PermissionSettings)
                .WithOptional()
                .HasForeignKey(ps=>ps.RoleId).WillCascadeOnDelete(false);

        }
    }
}
