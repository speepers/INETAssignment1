namespace INETAssignment1.Models
{
    public class Location
    {
        public int locationID { get; set; }
        public string locationName { get; set; } = string.Empty;
        public string locationDescription {  get; set; } = string.Empty;
        public List<Concert>? concerts { get; set; }

    }
}
