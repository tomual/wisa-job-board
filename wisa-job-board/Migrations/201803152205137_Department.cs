namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Department : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Department", c => c.String(nullable: false, defaultValue: "Default"));
            AlterColumn("dbo.Jobs", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Location", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Jobs", "Department");
        }
    }
}
