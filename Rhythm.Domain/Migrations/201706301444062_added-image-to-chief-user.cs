namespace Rhythm.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedimagetochiefuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChiefUsers", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChiefUsers", "ImagePath");
        }
    }
}
