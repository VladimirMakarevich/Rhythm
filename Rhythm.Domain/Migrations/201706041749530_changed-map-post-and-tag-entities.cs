namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmappostandtagentities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostTagMaps", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostTagMaps", "TagId", "dbo.Tags");
            DropIndex("dbo.PostTagMaps", new[] { "TagId" });
            DropIndex("dbo.PostTagMaps", new[] { "PostId" });
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
            
            DropTable("dbo.PostTagMaps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostTagMaps",
                c => new
                    {
                        PostTagMapId = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostTagMapId);
            
            DropForeignKey("dbo.PostTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostTags", new[] { "Tag_Id" });
            DropIndex("dbo.PostTags", new[] { "Post_Id" });
            DropTable("dbo.PostTags");
            CreateIndex("dbo.PostTagMaps", "PostId");
            CreateIndex("dbo.PostTagMaps", "TagId");
            AddForeignKey("dbo.PostTagMaps", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostTagMaps", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
