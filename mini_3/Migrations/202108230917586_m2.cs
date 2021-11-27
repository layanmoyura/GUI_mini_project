namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Password");
        }
    }
}
