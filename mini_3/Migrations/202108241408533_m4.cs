namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID);
            
            AddColumn("dbo.Users", "Ticket_TicketID", c => c.Int());
            CreateIndex("dbo.Users", "Ticket_TicketID");
            AddForeignKey("dbo.Users", "Ticket_TicketID", "dbo.Tickets", "TicketID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Ticket_TicketID", "dbo.Tickets");
            DropIndex("dbo.Users", new[] { "Ticket_TicketID" });
            DropColumn("dbo.Users", "Ticket_TicketID");
            DropTable("dbo.Tickets");
        }
    }
}
