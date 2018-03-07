namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.Applications", "FirstName");
            DropColumn("dbo.Applications", "LastName");
            DropColumn("dbo.Applications", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "Location", c => c.String());
            AddColumn("dbo.Applications", "LastName", c => c.String());
            AddColumn("dbo.Applications", "FirstName", c => c.String());
            DropColumn("dbo.Applications", "FullName");
        }
    }
}
