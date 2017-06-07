namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddependencytochiefuserfromportfolioasonуtomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiefUsers", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.ChiefUsers", new[] { "PortfolioId" });
            AddColumn("dbo.Portfolios", "ChiefUserId", c => c.Int());
            CreateIndex("dbo.Portfolios", "ChiefUserId");
            AddForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Portfolios", "ChiefUserId", "dbo.ChiefUsers");
            DropIndex("dbo.Portfolios", new[] { "ChiefUserId" });
            DropColumn("dbo.Portfolios", "ChiefUserId");
            CreateIndex("dbo.ChiefUsers", "PortfolioId");
            AddForeignKey("dbo.ChiefUsers", "PortfolioId", "dbo.Portfolios", "Id", cascadeDelete: true);
        }
    }
}
