namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Ticket_TicketID", "dbo.Tickets");
            DropIndex("dbo.Users", new[] { "Ticket_TicketID" });
            AddColumn("dbo.Tickets", "User_UserID", c => c.Int());
            CreateIndex("dbo.Tickets", "User_UserID");
            AddForeignKey("dbo.Tickets", "User_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.Users", "Ticket_TicketID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Ticket_TicketID", c => c.Int());
            DropForeignKey("dbo.Tickets", "User_UserID", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "User_UserID" });
            DropColumn("dbo.Tickets", "User_UserID");
            CreateIndex("dbo.Users", "Ticket_TicketID");
            AddForeignKey("dbo.Users", "Ticket_TicketID", "dbo.Tickets", "TicketID");
        }
    }
}
