using LMS.Posts;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EntityMapper
{
    public class PostLevelCfg : EntityTypeConfiguration<PostLevel>
    {
        public PostLevelCfg()
        {
            ToTable("PostLevel");

            Property(pl => pl.Name)
                .IsRequired()
                .HasMaxLength(PostLevel.MaxPostLevelLength);

            Property(pl => pl.Level)
                .IsRequired();
        }
    }
}
