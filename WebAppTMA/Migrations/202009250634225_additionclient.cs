﻿namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionclient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Client", "address", c => c.String());
            AddColumn("dbo.tbl_Client", "phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Client", "phone");
            DropColumn("dbo.tbl_Client", "address");
        }
    }
}
