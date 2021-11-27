namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationID = c.Int(nullable: false, identity: true),
                        Crowd_capacity = c.Int(nullable: false),
                        Admin_AdminID = c.Int(),
                    })
                .PrimaryKey(t => t.StationID)
                .ForeignKey("dbo.Admins", t => t.Admin_AdminID)
                .Index(t => t.Admin_AdminID);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        TrainID = c.Int(nullable: false),
                        Starting_at = c.String(),
                        Destination = c.String(),
                        Starting_time = c.String(),
                        Ending_time = c.String(),
                        Location = c.String(),
                        Available_seats = c.String(),
                        Admin_AdminID = c.Int(),
                    })
                .PrimaryKey(t => t.TrainID)
                .ForeignKey("dbo.Admins", t => t.Admin_AdminID)
                .Index(t => t.Admin_AdminID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trains", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Stations", "Admin_AdminID", "dbo.Admins");
            DropIndex("dbo.Trains", new[] { "Admin_AdminID" });
            DropIndex("dbo.Stations", new[] { "Admin_AdminID" });
            DropTable("dbo.Trains");
            DropTable("dbo.Stations");
        }
    }
}
