namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedprojectentityaddeddescriptionproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Description");
        }
    }
}
