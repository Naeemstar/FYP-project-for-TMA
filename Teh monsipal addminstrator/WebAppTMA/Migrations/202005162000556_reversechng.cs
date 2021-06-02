namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reversechng : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tbl_user", "RoleId");
            AddForeignKey("dbo.tbl_user", "RoleId", "dbo.tbl_Role", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_user", "RoleId", "dbo.tbl_Role");
            DropIndex("dbo.tbl_user", new[] { "RoleId" });
        }
    }
}
