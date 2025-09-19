namespace INETAssignment1.Models
{
    public class Concert
    {
        public int concertID { get; set; }
        public string concertName { get; set; } = string.Empty;
        public string concertGenre { get; set; } = string.Empty;
        public string tourName { get; set; } = string.Empty;
        public Band? headliningBand { get; set; }
        public List<String>? supportingBands { get; set; }
        public Location? concertLocation {  get; set; }
        public DateTime concertTime {  get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
