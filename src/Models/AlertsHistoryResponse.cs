using IsraelHomeFrontCommandAPI.Enums;

namespace IsraelHomeFrontCommandAPI.Models
{
    public class AlertHistoryResponse
    {
        public DateTime AlertDateIst {  get; set; }

        public HistoryAlertType AlertType { get; set; }

        public string? City { get; set; }
    }
}
