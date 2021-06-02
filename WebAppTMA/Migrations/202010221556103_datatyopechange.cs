namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatyopechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_SuccessDeplyment", "project_Budget", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_SuccessDeplyment", "project_Budget", c => c.Int(nullable: false));
        }
    }
}
