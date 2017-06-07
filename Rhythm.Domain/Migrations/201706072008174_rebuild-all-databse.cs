namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rebuildalldatabse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        DescriptionCategory = c.String(),
                        CountCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        NameSenderPost = c.String(),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        DescriptionPost = c.String(),
                        UrlSlug = c.String(),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        ImageData = c.Binary(),
                        ImageMime = c.String(),
                        CountComments = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        NameUserSender = c.String(),
                        EmailUserSender = c.String(),
                        DescriptionComment = c.Boolean(nullable: false),
                        CommentMessage = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        DescriptionTag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChiefUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Birth = c.String(),
                        Email = c.String(),
                        HomeAddress = c.String(),
                        Skype = c.String(),
                        Mobile = c.String(),
                        Github = c.String(),
                        Linkedin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChiefUserId = c.Int(),
                        NamePortfolio = c.String(),
                        Objective = c.String(),
                        Summary = c.String(),
                        Skills = c.String(),
                        EnglishProficiency = c.String(),
                        WorkExp = c.String(),
                        Education = c.String(),
                        ApplicationSystems = c.String(),
                        AdditionalInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChiefUsers", t => t.ChiefUserId)
                .Index(t => t.ChiefUserId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PortfolioId = c.Int(),
                        NameProject = c.String(),
                        Framework = c.String(),
                        Database = c.String(),
                        IDE = c.String(),
                        StackTechnologies = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        Post_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.Tag_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers");
            DropForeignKey("dbo.PostTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PostTags", new[] { "Tag_Id" });
            DropIndex("dbo.PostTags", new[] { "Post_Id" });
            DropIndex("dbo.Projects", new[] { "PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "ChiefUserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.PostTags");
            DropTable("dbo.Projects");
            DropTable("dbo.Portfolios");
            DropTable("dbo.ChiefUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
