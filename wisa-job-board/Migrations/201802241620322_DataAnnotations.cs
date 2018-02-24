namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Title", c => c.String(maxLength: 60));
            AlterColumn("dbo.Jobs", "Location", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Description", c => c.String());
            AlterColumn("dbo.Jobs", "Location", c => c.String());
            AlterColumn("dbo.Jobs", "Title", c => c.String());
        }
    }
}
