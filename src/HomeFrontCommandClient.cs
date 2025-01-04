using IsraelHomeFrontCommandAPI.Enums;
using IsraelHomeFrontCommandAPI.Models;
using IsraelHomeFrontCommandAPI.Services;
using Newtonsoft.Json;

namespace IsraelHomeFrontCommandAPI
{
    public class HomeFrontCommandClient
    {
        private readonly HttpClient _httpClient;
        private readonly Language _language;
        private readonly CityService _cityService;

        public HomeFrontCommandClient(Language language = Language.Hebrew)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://www.oref.org.il/warningMessages/alert/");
            _cityService = new CityService("cities.json");
            _language = language;
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

                var apiResponse = JsonConvert.DeserializeObject<CurrentAlertApiResponse>(jsonResponse);

                if (apiResponse == null)
                {
                    return new ActiveAlertsResponse() { AlertType = AlertType.None };
                }

                return new ActiveAlertsResponse()
                {
                    AlertType = apiResponse.Cat.HasValue ? (AlertType)apiResponse.Cat.Value : AlertType.Unknown,
                    Instructions = apiResponse.Desc,
                    Cities = apiResponse.Data
                        .Select(city => _cityService.GetCityNameByLanguage(city, _language))
                        .ToList()
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
            List<AlertHistoryResponse> alertHistory = [];

            try
            {
                var response = await _httpClient.GetAsync("History/AlertsHistory.json");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<List<AlertData>>(jsonResponse);

                if (apiResponse == null || !apiResponse.Any())
                {
                    return alertHistory;
                }

                foreach (var alert in apiResponse)
                {
                    alertHistory.Add(new AlertHistoryResponse()
                    {
                        AlertDateIst = alert.AlertDate,
                        AlertType = alert.Category.HasValue ? (HistoryAlertType)alert.Category.Value : HistoryAlertType.Unknown,
                        City = _cityService.GetCityNameByLanguage(alert.Data, _language) 
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
