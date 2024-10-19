using IsraelHomeFrontCommandAPI.Models;
using Newtonsoft.Json;

namespace IsraelHomeFrontCommandAPI
{
    public class HomeFrontCommandClient
    {
        private readonly HttpClient _httpClient;

        public HomeFrontCommandClient()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("https://www.oref.org.il/warningMessages/alert/");
        }

        /// <summary>
        /// Get active alerts.
        /// </summary>
        /// <returns>A list of active alerts.</returns>
        public async Task<List<Alert>> GetActiveAlertsAsync()
        {
            var response = await _httpClient.GetAsync("Alerts.json");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var alerts = JsonConvert.DeserializeObject<List<Alert>>(jsonResponse);

            return alerts;
        }
    }
}
