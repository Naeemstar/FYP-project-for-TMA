namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updationss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Client", "clientType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Client", "clientType", c => c.Int(nullable: false));
        }
    }
}
