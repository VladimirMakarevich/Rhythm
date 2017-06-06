namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allownullabletouserandprojects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers");
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Portfolios", new[] { "ChiefUserId" });
            DropIndex("dbo.Projects", new[] { "PortfolioId" });
            AlterColumn("dbo.Portfolios", "ChiefUserId", c => c.Int());
            AlterColumn("dbo.Projects", "PortfolioId", c => c.Int());
            CreateIndex("dbo.Portfolios", "ChiefUserId");
            CreateIndex("dbo.Projects", "PortfolioId");
            AddForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers", "ChiefUserId");
            AddForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios", "PortfolioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers");
            DropIndex("dbo.Projects", new[] { "PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "ChiefUserId" });
            AlterColumn("dbo.Projects", "PortfolioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Portfolios", "ChiefUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "PortfolioId");
            CreateIndex("dbo.Portfolios", "ChiefUserId");
            AddForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
            AddForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers", "ChiefUserId", cascadeDelete: true);
        }
    }
}
