namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedporfolioadfromchiefuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ChiefUsers", "PortfolioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChiefUsers", "PortfolioId", c => c.Int(nullable: false));
        }
    }
}
