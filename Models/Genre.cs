namespace INETAssignment1.Models
{
    public class Genre
    {
        public int genreID { get; set; }
        public string genreName { get; set; } = string.Empty;
        public string genreDescription { get; set; } = string.Empty;

        public ICollection<Band>? bands { get; set; } = new List<Band>();

        public List<Concert>? concerts { get; set; }
    }
}
