using System;
using System.Linq;
using LMS.EntityFramework;
using LMS.Teams;

namespace LMS.Migrations.Seed
{
    internal class DefaultTeamCreator
    {
        private readonly LmsDbContext _context;

        public DefaultTeamCreator(LmsDbContext context)
        {
            this._context = context;
        }

        public void Create()
        {
            var defaultTeam = _context.Teams.FirstOrDefault(e => e.DisplayName == TeamManager.DefaultTeamName);
            if (defaultTeam == null)
            {
                defaultTeam = new Team { DisplayName = TeamManager.DefaultTeamName, Code = "0000.0000.0000", ParentId = Guid.Empty };
                _context.Teams.Add(defaultTeam);
                _context.SaveChanges();
            }
        }
    }
}
