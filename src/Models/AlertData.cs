namespace IsraelHomeFrontCommandAPI.Models
{
    public class AlertData
    {
        public DateTime AlertDate {  get; set; }

        public string? Title { get; set; }

        public required string Data {  get; set; }

        public int? Category { get; set; }
    }
}