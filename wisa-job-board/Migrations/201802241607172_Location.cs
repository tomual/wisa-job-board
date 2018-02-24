namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Location", c => c.String());
            DropColumn("dbo.Jobs", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Department", c => c.String());
            DropColumn("dbo.Jobs", "Location");
        }
    }
}
