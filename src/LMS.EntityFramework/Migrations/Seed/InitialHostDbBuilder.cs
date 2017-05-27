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
        private readonly LmsDbContext _context;

        public InitialHostDbBuilder(LmsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultTeamCreator(_context).Create();
            new DefaultRoleAndUserCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
