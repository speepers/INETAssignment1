using System.ComponentModel.DataAnnotations;

namespace INETAssignment1.Models
{
    public class Band
    {
        public int bandID { get; set; } // PK

        [Display(Name = "Band Name")]
        public string bandName { get; set; } = string.Empty;

        [Display(Name = "Band Description")]
        public string bandDescription { get; set; } = string.Empty;

        [Display(Name = "Genre ID")]
        public int genreID { get; set; }

        [Display(Name = "Genre Name")]
        public Genre? genre { get; set; }

        public ICollection<Concert>? concerts { get; set; } = new List<Concert>();
    }
}
