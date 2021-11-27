namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trains", "Available_seats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trains", "Available_seats", c => c.String());
        }
    }
}
