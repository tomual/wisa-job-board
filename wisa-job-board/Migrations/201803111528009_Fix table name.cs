namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixtablename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Applications1", newName: "Applications");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Applications", newName: "Applications1");
        }
    }
}
