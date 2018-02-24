namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "OwnerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "OwnerID");
        }
    }
}
