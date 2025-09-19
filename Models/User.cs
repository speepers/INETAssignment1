namespace INETAssignment1.Models
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public List<Ticket>? purchasedTickets { get; set; }
    }
}
