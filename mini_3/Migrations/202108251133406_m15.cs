namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notices", "Station_StationID", "dbo.Stations");
            DropPrimaryKey("dbo.Stations");
            AlterColumn("dbo.Stations", "StationID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Stations", "StationID");
            AddForeignKey("dbo.Notices", "Station_StationID", "dbo.Stations", "StationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notices", "Station_StationID", "dbo.Stations");
            DropPrimaryKey("dbo.Stations");
            AlterColumn("dbo.Stations", "StationID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Stations", "StationID");
            AddForeignKey("dbo.Notices", "Station_StationID", "dbo.Stations", "StationID");
        }
    }
}
