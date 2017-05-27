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
                        ParentId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Guid(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Guid(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permission", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.RecTeam",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TableId = c.Guid(nullable: false),
                        TeamId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
                        Role_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.TableId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.TableId)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.TableId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_Id)
                .Index(t => t.TableId)
                .Index(t => t.TeamId)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 95),
                        DisplayName = c.String(nullable: false, maxLength: 256),
                        ParentId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Guid(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Guid(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
                        Team_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        TeamId = c.Guid(),
                        PostLevelId = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Guid(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Guid(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
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
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPost",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        IsMain = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        PostStatus = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
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
                        Surname = c.String(maxLength: 64),
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
                        CreatorUserId = c.Guid(),
                        DeleterUserId = c.Guid(),
                        LastModifierUserId = c.Guid(),
                        TeamId = c.Guid(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
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
                "dbo.PermissionSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsGranted = c.Boolean(nullable: false),
                        Name = c.String(),
                        RoleId = c.Guid(),
                        UserId = c.Guid(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Guid(),
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
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RecTeam", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.PermissionSetting", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RecTeam", "TableId", "dbo.Permission");
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
            DropForeignKey("dbo.Team", "Team_Id", "dbo.Team");
            DropForeignKey("dbo.Permission", "ParentId", "dbo.Permission");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.PermissionSetting", new[] { "UserId" });
            DropIndex("dbo.PermissionSetting", new[] { "RoleId" });
            DropIndex("dbo.User", new[] { "TeamId" });
            DropIndex("dbo.User", new[] { "LastModifierUserId" });
            DropIndex("dbo.User", new[] { "DeleterUserId" });
            DropIndex("dbo.User", new[] { "CreatorUserId" });
            DropIndex("dbo.UserPost", new[] { "PostId" });
            DropIndex("dbo.UserPost", new[] { "UserId" });
            DropIndex("dbo.Post", new[] { "PostLevelId" });
            DropIndex("dbo.Post", new[] { "TeamId" });
            DropIndex("dbo.Team", new[] { "Team_Id" });
            DropIndex("dbo.RecTeam", new[] { "Role_Id" });
            DropIndex("dbo.RecTeam", new[] { "TeamId" });
            DropIndex("dbo.RecTeam", new[] { "TableId" });
            DropIndex("dbo.Permission", new[] { "ParentId" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.Role",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.UserRole");
            DropTable("dbo.PermissionSetting");
            DropTable("dbo.User",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.UserPost");
            DropTable("dbo.PostLevel");
            DropTable("dbo.Post");
            DropTable("dbo.Team");
            DropTable("dbo.RecTeam");
            DropTable("dbo.Permission");
        }
    }
}
