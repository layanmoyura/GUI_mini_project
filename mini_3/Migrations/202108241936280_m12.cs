namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Trains");
            AlterColumn("dbo.Trains", "TrainID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Trains", "TrainID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Trains");
            AlterColumn("dbo.Trains", "TrainID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Trains", "TrainID");
        }
    }
}
