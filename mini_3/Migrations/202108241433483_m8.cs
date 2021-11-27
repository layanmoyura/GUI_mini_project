namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Card_no = c.String(),
                        Name_on_card = c.String(),
                        Bank = c.String(),
                        Card_type = c.String(),
                        Payment_date = c.String(),
                        Pin = c.String(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.Ticket_TicketID);
            
            AddColumn("dbo.Classes", "Admin_AdminID", c => c.Int());
            CreateIndex("dbo.Classes", "Admin_AdminID");
            AddForeignKey("dbo.Classes", "Admin_AdminID", "dbo.Admins", "AdminID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Classes", "Admin_AdminID", "dbo.Admins");
            DropIndex("dbo.Payments", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Classes", new[] { "Admin_AdminID" });
            DropColumn("dbo.Classes", "Admin_AdminID");
            DropTable("dbo.Payments");
        }
    }
}
