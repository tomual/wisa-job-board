namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnetomanyJobsandApplications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "Job_ID", c => c.Int());
            CreateIndex("dbo.Applications", "Job_ID");
            AddForeignKey("dbo.Applications", "Job_ID", "dbo.Jobs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "Job_ID", "dbo.Jobs");
            DropIndex("dbo.Applications", new[] { "Job_ID" });
            DropColumn("dbo.Applications", "Job_ID");
        }
    }
}
