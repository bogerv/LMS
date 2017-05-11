using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;
using LMS.Authorization.Users;
using LMS.Authorization.Roles;
using LMS.Posts;
using LMS.RecTeams;
using LMS.Teams;
using LMS.EntityMapper;
using LMS.Authorization.Permissions;
using System.Reflection;
using System.Linq;
using System;
using System.Data.Entity.ModelConfiguration;

namespace LMS.EntityFramework
{
    public class LMSDbContext : AbpDbContext
    {
        // Define an IDbSet for each Entity...
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Role> Roles { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<PostLevel> PostLevels { get; set; }
        public virtual IDbSet<UserPost> UserPosts { get; set; }
        public virtual IDbSet<UserRole> UserRoles { get; set; }
        public virtual IDbSet<Permission> Permissions { get; set; }
        public virtual IDbSet<PermissionSetting> PermissionSettings { get; set; }
        public virtual IDbSet<RecTeam> RecTeams { get; set; }
        public virtual IDbSet<Team> Teams { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public LMSDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in LMSDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of LMSDbContext since ABP automatically handles it.
         */
        public LMSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public LMSDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public LMSDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 表名去掉Abp自带的prefix('abp') 例: 由AbpUsers改为Users
            //modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
            //modelBuilder.Entity<UserClaim>().ToTable("UserClaims");

            // 手动添加
            //modelBuilder.Configurations.Add(new UserCfg())
            //    .Add(new UserPostCfg()).Add(new TeamCfg())
            //    .Add(new PostCfg()).Add(new RoleCfg()).Add(new PostLevelCfg()).Add(new UserRoleCfg());

            // 使用反射获取所有继承自 EntityTypeConfiguration<> 的所有类
            // 循环添加到 modelBuilder.Configurations 中
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //                              .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //                              .Where(type => type.BaseType != null && type.BaseType.IsGenericType
            //                                                                   && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            // 使用提供的方法
            modelBuilder.Configurations.AddFromAssembly(typeof(LMSDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
