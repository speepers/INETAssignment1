using System.ComponentModel.DataAnnotations;

namespace INETAssignment1.Models
{
    public class Purchase
    {
        public int purchaseID { get; set; } //PK
        public Concert? Concert { get; set; } //FK
        [Display(Name = "Concert")]
        public int concertID { get; set; }
        [Display(Name = "Number of Tickets Ordered")]
        public int ticketsOrdered { get; set; }
        [Display(Name = "Order Date")]
        public DateTime orderDate { get; set; }
        [Display(Name = "Customer Name")]
        public string customerName { get; set; } = string.Empty;
        [Display(Name = "Customer Email")]
        public string customerEmail { get; set; } = string.Empty;
        [Display(Name = "Credit Card Number")]
        public int creditCardNumber { get; set; }
        [Display(Name = "CVV")]
        public int CVV { get; set; }
        [Display(Name = "Expiry Date")]
        public DateTime expiryDate { get; set; }

    }
}
