namespace LMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Description = c.String(),
                        TenantId = c.Int(),
                        ParentId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Permission_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permission", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.PermissionSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsGranted = c.Boolean(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                        RoleId = c.Guid(),
                        UserId = c.Guid(),
                        TenantId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permission", t => t.PermissionId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.PermissionId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RecTeam",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TableId = c.Guid(nullable: false),
                        TeamId = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Permission_Id = c.Guid(),
                        Role_Id = c.Guid(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RecTeam_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.TableId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.TableId)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.Permission_Id)
                .ForeignKey("dbo.Role", t => t.Role_Id)
                .Index(t => t.TableId)
                .Index(t => t.TeamId)
                .Index(t => t.Permission_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 95),
                        DisplayName = c.String(nullable: false, maxLength: 256),
                        ParentId = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Team_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Team_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        TeamId = c.Guid(),
                        PostLevelId = c.Guid(),
                        TenantId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Post_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Post_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostLevel", t => t.PostLevelId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.PostLevelId);
            
            CreateTable(
                "dbo.PostLevel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Level = c.Int(nullable: false),
                        TenantId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PostLevel_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PostLevel_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPost",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        IsMain = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        PostStatus = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserPost_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 64),
                        Name = c.String(nullable: false, maxLength: 64),
                        Surname = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 256),
                        EmailAddress = c.String(nullable: false, maxLength: 256),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        PasswordResetCode = c.String(),
                        ProfilePicture = c.String(),
                        LastLoginTime = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        DeletionTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        TenantId = c.Int(),
                        CreatorUserId = c.Guid(nullable: false),
                        DeleterUserId = c.Guid(nullable: false),
                        LastModifierUserId = c.Guid(nullable: false),
                        TeamId = c.Guid(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatorUserId)
                .ForeignKey("dbo.User", t => t.DeleterUserId)
                .ForeignKey("dbo.User", t => t.LastModifierUserId)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.CreatorUserId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(nullable: false),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        DisplayName = c.String(),
                        Description = c.String(),
                        IsStatic = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        TenantId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        DeletionTime = c.DateTime(),
                        CreatorUserId = c.Guid(nullable: false),
                        DeleterUserId = c.Guid(nullable: false),
                        LastModifierUserId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RecTeam", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.PermissionSetting", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RecTeam", "Permission_Id", "dbo.Permission");
            DropForeignKey("dbo.RecTeam", "TeamId", "dbo.Team");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPost", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "TeamId", "dbo.Team");
            DropForeignKey("dbo.RecTeam", "TableId", "dbo.User");
            DropForeignKey("dbo.PermissionSetting", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.User", "DeleterUserId", "dbo.User");
            DropForeignKey("dbo.User", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.UserPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "TeamId", "dbo.Team");
            DropForeignKey("dbo.RecTeam", "TableId", "dbo.Post");
            DropForeignKey("dbo.Post", "PostLevelId", "dbo.PostLevel");
            DropForeignKey("dbo.Team", "ParentId", "dbo.Team");
            DropForeignKey("dbo.PermissionSetting", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.Permission", "ParentId", "dbo.Permission");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "TeamId" });
            DropIndex("dbo.User", new[] { "LastModifierUserId" });
            DropIndex("dbo.User", new[] { "DeleterUserId" });
            DropIndex("dbo.User", new[] { "CreatorUserId" });
            DropIndex("dbo.UserPost", new[] { "PostId" });
            DropIndex("dbo.UserPost", new[] { "UserId" });
            DropIndex("dbo.Post", new[] { "PostLevelId" });
            DropIndex("dbo.Post", new[] { "TeamId" });
            DropIndex("dbo.Team", new[] { "ParentId" });
            DropIndex("dbo.RecTeam", new[] { "Role_Id" });
            DropIndex("dbo.RecTeam", new[] { "Permission_Id" });
            DropIndex("dbo.RecTeam", new[] { "TeamId" });
            DropIndex("dbo.RecTeam", new[] { "TableId" });
            DropIndex("dbo.PermissionSetting", new[] { "UserId" });
            DropIndex("dbo.PermissionSetting", new[] { "RoleId" });
            DropIndex("dbo.PermissionSetting", new[] { "PermissionId" });
            DropIndex("dbo.Permission", new[] { "ParentId" });
            DropTable("dbo.Role",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.UserRole",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.User",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.UserPost",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserPost_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PostLevel",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PostLevel_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PostLevel_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Post",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Post_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Post_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Team",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Team_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Team_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.RecTeam",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RecTeam_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PermissionSetting",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Permission",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Permission_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
