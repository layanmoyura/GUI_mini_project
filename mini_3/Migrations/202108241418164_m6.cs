namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        Price_per_unit_distance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID);
            
            AddColumn("dbo.Tickets", "Class_ClassID", c => c.Int());
            CreateIndex("dbo.Tickets", "Class_ClassID");
            AddForeignKey("dbo.Tickets", "Class_ClassID", "dbo.Classes", "ClassID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Class_ClassID", "dbo.Classes");
            DropIndex("dbo.Tickets", new[] { "Class_ClassID" });
            DropColumn("dbo.Tickets", "Class_ClassID");
            DropTable("dbo.Classes");
        }
    }
}
