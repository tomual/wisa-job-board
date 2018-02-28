namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class File : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "File");
        }
    }
}
