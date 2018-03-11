namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationModelRename : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        ResumePath = c.String(),
                        DateApplied = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applications1");
        }
    }
}
