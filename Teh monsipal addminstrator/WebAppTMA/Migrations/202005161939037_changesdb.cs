namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_user", "RoleId", "dbo.tbl_Role");
            DropIndex("dbo.tbl_user", new[] { "RoleId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.tbl_user", "RoleId");
            AddForeignKey("dbo.tbl_user", "RoleId", "dbo.tbl_Role", "RoleId", cascadeDelete: true);
        }
    }
}
