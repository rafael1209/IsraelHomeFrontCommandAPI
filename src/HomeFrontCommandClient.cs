using IsraelHomeFrontCommandAPI.Enums;
using IsraelHomeFrontCommandAPI.Models;
using Newtonsoft.Json;
using System;

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
        public async Task<ActiveAlertsResponse> GetActiveAlertsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Alerts.json");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                ApiResponse? apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                if (apiResponse == null)
                    return new ActiveAlertsResponse() { AlertType = AlertType.None};

                return new ActiveAlertsResponse()
                {
                    AlertType = apiResponse.Cat.HasValue ? (AlertType)apiResponse.Cat.Value : AlertType.Unknown
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
