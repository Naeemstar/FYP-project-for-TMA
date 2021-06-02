namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changdatabseee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Client", "clientType", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Client", "address", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Client", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Role", "RoleName", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Resources", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Resources", "quantity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Resources", "quantity", c => c.String());
            AlterColumn("dbo.tbl_Resources", "Name", c => c.String());
            AlterColumn("dbo.tbl_Role", "RoleName", c => c.String());
            AlterColumn("dbo.Contacts", "Message", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
            AlterColumn("dbo.tbl_Client", "phone", c => c.String());
            AlterColumn("dbo.tbl_Client", "address", c => c.String());
            AlterColumn("dbo.tbl_Client", "clientType", c => c.String());
        }
    }
}
