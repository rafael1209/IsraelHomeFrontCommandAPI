using System.Text.Json.Serialization;

namespace IsraelHomeFrontCommandAPI.Models
{
    public class CityData
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("areaid")]
        public int AreaId { get; set; }

        [JsonPropertyName("areaname")]
        public string AreaName { get; set; }

        [JsonPropertyName("label_he")]
        public string LabelHe { get; set; }

        [JsonPropertyName("migun_time")]
        public int MigunTime { get; set; }
    }
}
