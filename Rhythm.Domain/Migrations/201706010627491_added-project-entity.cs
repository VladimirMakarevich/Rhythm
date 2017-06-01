namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprojectentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiefUsers", "PortfolioID", "dbo.Portfolios");
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.ChiefUsers", new[] { "PortfolioID" });
            DropIndex("dbo.TagPosts", new[] { "Tag_ID" });
            DropIndex("dbo.TagPosts", new[] { "Post_ID" });
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        PortfolioId = c.Int(nullable: false),
                        NameProject = c.String(),
                        Framework = c.String(),
                        Database = c.String(),
                        IDE = c.String(),
                        StackTechnologies = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
            AddColumn("dbo.Comments", "CommentMessage", c => c.String());
            AddColumn("dbo.Portfolios", "Objective", c => c.String());
            AddColumn("dbo.Portfolios", "EnglishProficiency", c => c.String());
            AddColumn("dbo.Portfolios", "ApplicationSystems", c => c.String());
            AddColumn("dbo.Portfolios", "ChiefUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
            CreateIndex("dbo.Portfolios", "ChiefUserId");
            CreateIndex("dbo.TagPosts", "Tag_Id");
            CreateIndex("dbo.TagPosts", "Post_Id");
            AddForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers", "ChiefUserId", cascadeDelete: true);
            DropColumn("dbo.Comments", "Comment1");
            DropColumn("dbo.ChiefUsers", "PortfolioID");
            DropColumn("dbo.Portfolios", "MyProjects");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolios", "MyProjects", c => c.String());
            AddColumn("dbo.ChiefUsers", "PortfolioID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Comment1", c => c.String());
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers");
            DropIndex("dbo.TagPosts", new[] { "Post_Id" });
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropIndex("dbo.Projects", new[] { "PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "ChiefUserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropColumn("dbo.Portfolios", "ChiefUserId");
            DropColumn("dbo.Portfolios", "ApplicationSystems");
            DropColumn("dbo.Portfolios", "EnglishProficiency");
            DropColumn("dbo.Portfolios", "Objective");
            DropColumn("dbo.Comments", "CommentMessage");
            DropTable("dbo.Projects");
            CreateIndex("dbo.TagPosts", "Post_ID");
            CreateIndex("dbo.TagPosts", "Tag_ID");
            CreateIndex("dbo.ChiefUsers", "PortfolioID");
            CreateIndex("dbo.Comments", "PostID");
            AddForeignKey("dbo.ChiefUsers", "PortfolioID", "dbo.Portfolios", "PortfolioID", cascadeDelete: true);
        }
    }
}
