namespace INETAssignment1.Models
{
    public class Ticket
    {
        public int ticketID { get; set; }
        public string ticketName { get; set; } = string.Empty;       
        public int concertID { get; set; }
        public double marketPrice { get; set; }

    }
}
