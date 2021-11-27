namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Distances",
                c => new
                    {
                        DistanceID = c.Int(nullable: false, identity: true),
                        Distance_from_origin_in_km = c.Int(nullable: false),
                        Station_StationID = c.Int(),
                    })
                .PrimaryKey(t => t.DistanceID)
                .ForeignKey("dbo.Stations", t => t.Station_StationID)
                .Index(t => t.Station_StationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Distances", "Station_StationID", "dbo.Stations");
            DropIndex("dbo.Distances", new[] { "Station_StationID" });
            DropTable("dbo.Distances");
        }
    }
}
