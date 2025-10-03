using System.ComponentModel.DataAnnotations;

namespace INETAssignment1.Models
{
    public class Location
    {
        public int locationID { get; set; } // PK

        [Display(Name = "Location Name")]
        public string locationName { get; set; } = string.Empty;

        [Display(Name = "Location Description")]
        public string locationDescription {  get; set; } = string.Empty;

        public ICollection<Concert>? concerts { get; set; } = new List<Concert>();

    }
}
