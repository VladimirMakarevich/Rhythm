namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationolddatabase : DbMigration
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
                        NameSenderPost = c.String(),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        DescriptionPost = c.String(),
                        UrlSlug = c.String(),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
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
                        PostID = c.Int(nullable: false),
                        NameUserSender = c.String(),
                        EmailUserSender = c.String(),
                        DescriptionComment = c.Boolean(nullable: false),
                        Comment1 = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
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
                        ChiefUserId = c.Int(nullable: false, identity: true),
                        PortfolioId = c.Int(),
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
                .PrimaryKey(t => t.ChiefUserId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        NamePortfolio = c.String(),
                        Summary = c.String(),
                        Skills = c.String(),
                        WorkExp = c.String(),
                        MyProjects = c.String(),
                        Education = c.String(),
                        AdditionalInfo = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioId);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiefUsers", "PortfolioID", "dbo.Portfolios");
            DropForeignKey("dbo.TagPosts", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TagPosts", new[] { "Post_ID" });
            DropIndex("dbo.TagPosts", new[] { "Tag_ID" });
            DropIndex("dbo.ChiefUsers", new[] { "PortfolioID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.Portfolios");
            DropTable("dbo.ChiefUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
