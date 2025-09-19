namespace INETAssignment1.Models
{
    public class Genre
    {
        public int genreID {  get; set; }
        public string genreName { get; set; } = string.Empty;
        public string genreDescription { get; set;} = string.Empty;
        public List<Concert>? concerts { get; set; }
    }
}
