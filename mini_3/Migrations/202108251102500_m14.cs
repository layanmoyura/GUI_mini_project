namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Stations");
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        NoticeID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Notice_content = c.String(),
                        Admin_AdminID = c.Int(),
                        Station_StationID = c.Int(),
                    })
                .PrimaryKey(t => t.NoticeID)
                .ForeignKey("dbo.Admins", t => t.Admin_AdminID)
                .ForeignKey("dbo.Stations", t => t.Station_StationID)
                .Index(t => t.Admin_AdminID)
                .Index(t => t.Station_StationID);
            
            AddColumn("dbo.Stations", "Station_name", c => c.String());
            AlterColumn("dbo.Stations", "StationID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Stations", "StationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notices", "Station_StationID", "dbo.Stations");
            DropForeignKey("dbo.Notices", "Admin_AdminID", "dbo.Admins");
            DropIndex("dbo.Notices", new[] { "Station_StationID" });
            DropIndex("dbo.Notices", new[] { "Admin_AdminID" });
            DropPrimaryKey("dbo.Stations");
            AlterColumn("dbo.Stations", "StationID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Stations", "Station_name");
            DropTable("dbo.Notices");
            AddPrimaryKey("dbo.Stations", "StationID");
        }
    }
}
