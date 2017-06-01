namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednullabletoportfolioId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiefUsers", "PortfolioID", "dbo.Portfolios");
            DropIndex("dbo.ChiefUsers", new[] { "PortfolioID" });
            AlterColumn("dbo.ChiefUsers", "PortfolioID", c => c.Int(nullable: false));
            CreateIndex("dbo.ChiefUsers", "PortfolioID");
            AddForeignKey("dbo.ChiefUsers", "PortfolioID", "dbo.Portfolios", "PortfolioID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiefUsers", "PortfolioID", "dbo.Portfolios");
            DropIndex("dbo.ChiefUsers", new[] { "PortfolioID" });
            AlterColumn("dbo.ChiefUsers", "PortfolioID", c => c.Int());
            CreateIndex("dbo.ChiefUsers", "PortfolioID");
            AddForeignKey("dbo.ChiefUsers", "PortfolioID", "dbo.Portfolios", "PortfolioID");
        }
    }
}
