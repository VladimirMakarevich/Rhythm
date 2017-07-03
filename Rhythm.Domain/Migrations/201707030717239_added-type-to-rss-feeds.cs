namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtypetorssfeeds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rsses", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rsses", "Type");
        }
    }
}
