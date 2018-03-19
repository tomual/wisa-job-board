namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requireresume : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "ResumePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "ResumePath", c => c.String());
            AlterColumn("dbo.Applications", "Email", c => c.String());
        }
    }
}
