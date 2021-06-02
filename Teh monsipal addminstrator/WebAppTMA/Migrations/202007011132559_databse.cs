namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fileTrackings", "RoleId", "dbo.tbl_Role");
            DropIndex("dbo.fileTrackings", new[] { "RoleId" });
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
                .PrimaryKey(t => t.fileId)
                .ForeignKey("dbo.tbl_user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.fileTrackings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.fileTrackings",
                c => new
                    {
                        Fileid = c.Int(nullable: false, identity: true),
                        file_Name = c.String(),
                        file_form = c.String(),
                        submitionDate = c.DateTime(nullable: false),
                        updateDate = c.DateTime(nullable: false),
                        submit_to = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Fileid);
            
            DropForeignKey("dbo.Files", "UserId", "dbo.tbl_user");
            DropIndex("dbo.Files", new[] { "UserId" });
            DropTable("dbo.Files");
            CreateIndex("dbo.fileTrackings", "RoleId");
            AddForeignKey("dbo.fileTrackings", "RoleId", "dbo.tbl_Role", "RoleId", cascadeDelete: true);
        }
    }
}
