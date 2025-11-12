using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INETAssignment1.Models
{
    public class Concert
    {
        public int concertID { get; set; } // PK

        [Display(Name = "Concert Name")]
        public string concertName { get; set; } = string.Empty;

        [Display(Name = "Tour Name")]
        public string tourName { get; set; } = string.Empty;

        [Display(Name = "Headlining Band")]
        public int? bandID { get; set; } // FK
        public Band? headliningBand { get; set; } 

        // Location (FK)
        [Display(Name = "Concert Location")]
        public int? locationID { get; set; } // FK
        public Location? concertLocation { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        [Display(Name = "Concert Time")]
        public DateTime concertTime { get; set; }

        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile? FormFile { get; set; } // nullable!
        public string filename { get; set; } = string.Empty;
        public ICollection<Purchase>? Purchases { get; set; }
    }
}