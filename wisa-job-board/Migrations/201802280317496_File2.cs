namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class File2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "UploadPath", c => c.String());
            DropColumn("dbo.Applications", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "File", c => c.String());
            DropColumn("dbo.Applications", "UploadPath");
        }
    }
}
