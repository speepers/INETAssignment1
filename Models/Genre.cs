using System.ComponentModel.DataAnnotations;

namespace INETAssignment1.Models
{
    public class Genre
    {
        public int genreID { get; set; } // PK

        [Display(Name = "Genre Name")]
        public string genreName { get; set; } = string.Empty;

        [Display(Name = "Genre Description")]
        public string genreDescription { get; set; } = string.Empty;

        public ICollection<Band>? bands { get; set; } = new List<Band>();
        public ICollection<Concert>? concerts { get; set; } = new List<Concert>();

    }
}