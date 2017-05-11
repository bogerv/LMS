using LMS.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EntityMapper
{
    public class UserRoleCfg : EntityTypeConfiguration<UserRole>
    {
        public UserRoleCfg()
        {
            ToTable("UserRole");
        }
    }
}
