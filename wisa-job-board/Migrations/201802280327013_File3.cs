namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class File3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "ResumePath", c => c.String());
            DropColumn("dbo.Applications", "UploadPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "UploadPath", c => c.String());
            DropColumn("dbo.Applications", "ResumePath");
        }
    }
}
