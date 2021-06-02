namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complainttblchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Complain", "UserId", "dbo.tbl_user");
            DropIndex("dbo.tbl_Complain", new[] { "UserId" });
            AddColumn("dbo.tbl_Complain", "Message", c => c.String());
            DropColumn("dbo.tbl_Complain", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Complain", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_Complain", "Message");
            CreateIndex("dbo.tbl_Complain", "UserId");
            AddForeignKey("dbo.tbl_Complain", "UserId", "dbo.tbl_user", "UserId", cascadeDelete: true);
        }
    }
}
