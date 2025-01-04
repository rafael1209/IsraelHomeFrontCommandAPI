namespace IsraelHomeFrontCommandAPI.Models
{
    public class CurrentAlertApiResponse
    {
        public string? Id { get; set; }
        public int? Cat { get; set; }
        public string? Title { get; set; }
        public required List<string> Data { get; set; }
        public string? Desc { get; set; }
    }
}