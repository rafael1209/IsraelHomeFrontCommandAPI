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
        /// Retrieves the current active alerts.
        /// </summary>
        /// <returns>A <see cref="ActiveAlertsResponse"/> object containing information about the active alert type.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request to the API fails.</exception>
        /// <exception cref="JsonSerializationException">Thrown when deserialization of the JSON response fails.</exception>
        public async Task<ActiveAlertsResponse> GetActiveAlertsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Alerts.json");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                CurrentAlertApiResponse? apiResponse = JsonConvert.DeserializeObject<CurrentAlertApiResponse>(jsonResponse);

                if (apiResponse == null)
                {
                    return new ActiveAlertsResponse() { AlertType = AlertType.None };
                }

                return new ActiveAlertsResponse()
                {
                    AlertType = apiResponse.Cat.HasValue ? (AlertType)apiResponse.Cat.Value : AlertType.Unknown
                };
            }
            catch (HttpRequestException httpEx)
            {
                throw new HttpRequestException("Error while making the request to the API.", httpEx);
            }
            catch (JsonSerializationException jsonEx)
            {
                throw new JsonSerializationException("Error deserializing the JSON response.", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unknown error occurred.", ex);
            }
        }

        /// <summary>
        /// Retrieves the alert history for the past 24 hours.
        /// </summary>
        /// <returns>A list of <see cref="AlertHistoryResponse"/> objects containing information about active alerts.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request to the API fails.</exception>
        /// <exception cref="JsonSerializationException">Thrown when deserialization of the JSON response fails.</exception>
        public async Task<List<AlertHistoryResponse>> GetAlertsHistoryLastDayAsync()
        {
            List<AlertHistoryResponse> alertHistory = new List<AlertHistoryResponse>();

            try
            {
                var response = await _httpClient.GetAsync("History/AlertsHistory.json");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                List<AlertData>? apiResponse = JsonConvert.DeserializeObject<List<AlertData>>(jsonResponse);

                if (apiResponse == null || !apiResponse.Any())
                {
                    return alertHistory;
                }

                foreach (var alert in apiResponse)
                {
                    AlertType alertType;
                    switch (alert.Title)
                    {
                        case "ירי רקטות וטילים":
                            alertType = AlertType.Missiles;
                            break;
                        case "חדירת כלי טיס עוין":
                            alertType = AlertType.HostileAircraftIntrusion;
                            break;
                        default:
                            alertType = AlertType.Unknown;
                            break;
                    }

                    alertHistory.Add(new AlertHistoryResponse()
                    {
                        AlertDateIst = alert.AlertDate,
                        AlertType = alertType,
                        City = alert.Data
                    });
                }

                return alertHistory;
            }
            catch (HttpRequestException httpEx)
            {
                throw new HttpRequestException("Error while making the request to the API.", httpEx);
            }
            catch (JsonSerializationException jsonEx)
            {
                throw new JsonSerializationException("Error deserializing the JSON response.", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unknown error occurred.", ex);
            }
        }
    }
}
