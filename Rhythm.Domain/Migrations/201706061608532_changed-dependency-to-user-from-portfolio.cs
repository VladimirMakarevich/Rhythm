namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddependencytouserfromportfolio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers");
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Portfolios", new[] { "ChiefUserId" });
            RenameColumn(table: "dbo.Portfolios", name: "ChiefUserId", newName: "Id");
            DropPrimaryKey("dbo.ChiefUsers");
            DropPrimaryKey("dbo.Portfolios");
            DropPrimaryKey("dbo.Projects");
            AddColumn("dbo.ChiefUsers", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Portfolios", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ChiefUsers", "Id");
            AddPrimaryKey("dbo.Portfolios", "Id");
            AddPrimaryKey("dbo.Projects", "Id");
            CreateIndex("dbo.Portfolios", "Id");
            AddForeignKey("dbo.Portfolios", "Id", "dbo.ChiefUsers", "Id");
            AddForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios", "Id");
            DropColumn("dbo.ChiefUsers", "ChiefUserId");
            DropColumn("dbo.Portfolios", "PortfolioId");
            DropColumn("dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Portfolios", "PortfolioId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ChiefUsers", "ChiefUserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "Id", "dbo.ChiefUsers");
            DropIndex("dbo.Portfolios", new[] { "Id" });
            DropPrimaryKey("dbo.Projects");
            DropPrimaryKey("dbo.Portfolios");
            DropPrimaryKey("dbo.ChiefUsers");
            AlterColumn("dbo.Portfolios", "Id", c => c.Int());
            DropColumn("dbo.Projects", "Id");
            DropColumn("dbo.ChiefUsers", "Id");
            AddPrimaryKey("dbo.Projects", "ProjectId");
            AddPrimaryKey("dbo.Portfolios", "PortfolioId");
            AddPrimaryKey("dbo.ChiefUsers", "ChiefUserId");
            RenameColumn(table: "dbo.Portfolios", name: "Id", newName: "ChiefUserId");
            CreateIndex("dbo.Portfolios", "ChiefUserId");
            AddForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios", "PortfolioId");
            AddForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers", "ChiefUserId");
        }
    }
}
