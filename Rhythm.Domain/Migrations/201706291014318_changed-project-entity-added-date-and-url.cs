namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedprojectentityaddeddateandurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Url", c => c.String());
            AddColumn("dbo.Projects", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Date");
            DropColumn("dbo.Projects", "Url");
        }
    }
}
