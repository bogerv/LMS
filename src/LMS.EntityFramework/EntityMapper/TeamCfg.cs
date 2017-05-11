using LMS.Teams;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EntityMapper
{
    public class TeamCfg : EntityTypeConfiguration<Team>
    {
        public TeamCfg()
        {
            ToTable("Team");

            Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(Team.MaxCodeLength);

            Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(Team.MaxDisplayNameLength);

            HasRequired(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(t => t.ParentId).WillCascadeOnDelete(false);
        }
    }
}
