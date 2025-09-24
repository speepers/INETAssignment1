namespace INETAssignment1.Models
{
    public class Concert
    {
        public int concertID { get; set; }
        public string concertName { get; set; } = string.Empty;
        public List<Genre>? concertGenres { get; set; }
        public string tourName { get; set; } = string.Empty;
        public Band? headliningBand { get; set; }
        public List<Band>? supportingBands { get; set; }
        public Location? concertLocation {  get; set; }
        public DateTime concertTime {  get; set; }
    }
}
