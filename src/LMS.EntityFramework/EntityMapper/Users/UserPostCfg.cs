using LMS.Authorization.Users;
using LMS.Posts;
using LMS.RecTeams;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EntityMapper
{
    public class UserPostCfg : EntityTypeConfiguration<UserPost>
    {
        public UserPostCfg()
        {
            ToTable("UserPost");

            Property(up => up.UserId).HasColumnOrder(1); // 配置列的展示顺序
            Property(up => up.PostId).HasColumnOrder(2); // 配置列的展示顺序

            //HasRequired<User>(up => up.User)    // UserPost requires NotNull User navigation property
            //    .WithMany(u => u.UserPosts)     // User has many UserPost
            //    .HasForeignKey(up => up.UserId);// User includes specified foreignkey property name for UserId

            //HasRequired<Post>(up => up.Post)    // UserPost requires NotNull User navigation property
            //    .WithMany(p => p.UserPosts)     // Post has many UserPost
            //    .HasForeignKey(up => up.PostId);// Post includes specified foreignkey property name for PostId
        }
    }
}
