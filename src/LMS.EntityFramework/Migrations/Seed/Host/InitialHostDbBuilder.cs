using LMS.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly LMSDbContext _context;

        public InitialHostDbBuilder(LMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultRoleAndUserCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
