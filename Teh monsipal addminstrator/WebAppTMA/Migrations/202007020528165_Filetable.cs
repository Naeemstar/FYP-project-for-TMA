namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Filetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        sumitionDate = c.DateTime(nullable: false),
                        FilePath = c.String(),
                        submit_to = c.String(),
                        submit_from = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Files");
        }
    }
}
