using LMS.Authorization.Permissions;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EntityMapper
{
    public class PermissionSettingCfg : EntityTypeConfiguration<PermissionSetting>
    {
        public PermissionSettingCfg()
        {
            ToTable("PermissionSetting");

            Property(ps => ps.UserId)
                .IsOptional();

            Property(ps => ps.RoleId)
                .IsOptional();
        }
    }
}
