namespace INETAssignment1.Models
{
    public class Band
    {
        public int bandID {  get; set; }
        public string bandName { get; set; } = string.Empty;
        public string bandDescription { get; set; } = string.Empty;
        public List<Genre>? genres { get; set; }
    }
}
