namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddependencytoportfoliofromuserasonetomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Portfolios", "Id", "dbo.ChiefUsers");
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Portfolios", new[] { "Id" });
            DropPrimaryKey("dbo.Portfolios");
            AddColumn("dbo.ChiefUsers", "PortfolioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Portfolios", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Portfolios", "Id");
            CreateIndex("dbo.ChiefUsers", "PortfolioId");
            AddForeignKey("dbo.ChiefUsers", "PortfolioId", "dbo.Portfolios", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.ChiefUsers", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.ChiefUsers", new[] { "PortfolioId" });
            DropPrimaryKey("dbo.Portfolios");
            AlterColumn("dbo.Portfolios", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.ChiefUsers", "PortfolioId");
            AddPrimaryKey("dbo.Portfolios", "Id");
            CreateIndex("dbo.Portfolios", "Id");
            AddForeignKey("dbo.Projects", "PortfolioId", "dbo.Portfolios", "Id");
            AddForeignKey("dbo.Portfolios", "Id", "dbo.ChiefUsers", "Id");
        }
    }
}
