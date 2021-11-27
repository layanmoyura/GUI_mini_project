namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "Price_per_unit_distance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "Price_per_unit_distance", c => c.String());
        }
    }
}
