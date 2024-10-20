using IsraelHomeFrontCommandAPI.Enums;

namespace IsraelHomeFrontCommandAPI.Models
{
    public class ActiveAlertsResponse
    {
        public AlertType AlertType { get; set; }

        public List<string>? Cities { get; set; }

        public string? Instructions { get; set; }
    }
}
