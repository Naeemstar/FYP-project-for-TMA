namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "UserId", "dbo.tbl_user");
            DropIndex("dbo.Files", new[] { "UserId" });
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        fileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        sumitionDate = c.DateTime(nullable: false),
                        file_form = c.String(),
                        updateDate = c.DateTime(nullable: false),
                        submit_to = c.String(),
                        submit_from = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.fileId);
            
            CreateIndex("dbo.Files", "UserId");
            AddForeignKey("dbo.Files", "UserId", "dbo.tbl_user", "UserId", cascadeDelete: true);
        }
    }
}
