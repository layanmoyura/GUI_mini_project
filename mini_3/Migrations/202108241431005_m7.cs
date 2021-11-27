namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "Price_per_unit_distance", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "Price_per_unit_distance", c => c.Single(nullable: false));
        }
    }
}
