namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unrequireresume : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "ResumePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "ResumePath", c => c.String(nullable: false));
        }
    }
}
