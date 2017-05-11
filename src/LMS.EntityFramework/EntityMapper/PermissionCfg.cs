using LMS.Authorization.Permissions;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EntityMapper
{
    public class PermissionCfg:EntityTypeConfiguration<Permission>
    {
        public PermissionCfg()
        {
            ToTable("Permission");

            HasRequired(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(t => t.ParentId).WillCascadeOnDelete(false);

            HasMany(p => p.PermissionSettings)
                .WithOptional()
                .HasForeignKey(ps => ps.PermissionId).WillCascadeOnDelete(false);
        }
    }
}
