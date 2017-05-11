using LMS.Posts;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EntityMapper
{
    public class PostCfg : EntityTypeConfiguration<Post>
    {
        public PostCfg()
        {
            ToTable("Post");

            HasMany(p => p.RecTeams)
                .WithOptional()
                .HasForeignKey(t => t.TableId);

            HasMany(r => r.UserPosts)
                .WithOptional()
                .HasForeignKey(ur => ur.PostId).WillCascadeOnDelete(false);
        }
    }
}
