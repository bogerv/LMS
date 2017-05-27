using LMS.Authorization.Permissions;
using System.Data.Entity.ModelConfiguration;

namespace LMS.EntityMapper
{
    public class PermissionCfg : EntityTypeConfiguration<Permission>
    {
        public PermissionCfg()
        {
            ToTable("Permission");

            HasMany(p => p.RecTeams)
                .WithOptional()
                .HasForeignKey(t => t.TableId);

            HasRequired(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(t => t.ParentId).WillCascadeOnDelete(false);
        }
    }
}
