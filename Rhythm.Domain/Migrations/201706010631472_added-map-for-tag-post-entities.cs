namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmapfortagpostentities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts");
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropIndex("dbo.TagPosts", new[] { "Post_Id" });
            CreateTable(
                "dbo.PostTagMaps",
                c => new
                    {
                        PostTagMapId = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostTagMapId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.PostId);
            
            DropTable("dbo.TagPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id });
            
            DropForeignKey("dbo.PostTagMaps", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTagMaps", "PostId", "dbo.Posts");
            DropIndex("dbo.PostTagMaps", new[] { "PostId" });
            DropIndex("dbo.PostTagMaps", new[] { "TagId" });
            DropTable("dbo.PostTagMaps");
            CreateIndex("dbo.TagPosts", "Post_Id");
            CreateIndex("dbo.TagPosts", "Tag_Id");
            AddForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
