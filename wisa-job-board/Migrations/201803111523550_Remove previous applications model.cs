namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removepreviousapplicationsmodel : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.Applications1", newName: "Applications");
            DropTable("dbo.Applications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Applications",
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
            
            //RenameTable(name: "dbo.Applications", newName: "Applications1");
        }
    }
}
