namespace WebAppTMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatbase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        clientType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Complain",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        complainType = c.String(),
                        complaindata = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tbl_user",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Contact = c.String(),
                        profile = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.tbl_Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tbl_Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.tbl_Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotifiType = c.String(),
                        NotifisubmitTo = c.String(),
                        NotifisubmitFrom = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tbl_planing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        planning_Type = c.String(),
                        planning_Payment = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.tbl_Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        quantity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_SuccessDeplyment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        project_Name = c.String(),
                        project_Budget = c.Int(nullable: false),
                        project_Status = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_SuccessDeplyment", "UserId", "dbo.tbl_user");
            DropForeignKey("dbo.tbl_planing", "UserId", "dbo.tbl_user");
            DropForeignKey("dbo.tbl_planing", "ClientId", "dbo.tbl_Client");
            DropForeignKey("dbo.tbl_Notification", "UserId", "dbo.tbl_user");
            DropForeignKey("dbo.tbl_Complain", "UserId", "dbo.tbl_user");
            DropForeignKey("dbo.tbl_user", "RoleId", "dbo.tbl_Role");
            DropIndex("dbo.tbl_SuccessDeplyment", new[] { "UserId" });
            DropIndex("dbo.tbl_planing", new[] { "ClientId" });
            DropIndex("dbo.tbl_planing", new[] { "UserId" });
            DropIndex("dbo.tbl_Notification", new[] { "UserId" });
            DropIndex("dbo.tbl_user", new[] { "RoleId" });
            DropIndex("dbo.tbl_Complain", new[] { "UserId" });
            DropTable("dbo.tbl_SuccessDeplyment");
            DropTable("dbo.tbl_Resources");
            DropTable("dbo.tbl_planing");
            DropTable("dbo.tbl_Notification");
            DropTable("dbo.tbl_Role");
            DropTable("dbo.tbl_user");
            DropTable("dbo.tbl_Complain");
            DropTable("dbo.tbl_Client");
        }
    }
}
