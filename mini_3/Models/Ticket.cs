namespace mini_3.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public float Value { get; set; }
        public User User { get; set; }
        public Class Class { get; set; }
        
    }
}
