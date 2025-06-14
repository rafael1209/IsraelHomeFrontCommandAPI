using IsraelHomeFrontCommandAPI.Enums;
using IsraelHomeFrontCommandAPI.Models;
using Newtonsoft.Json;

namespace IsraelHomeFrontCommandAPI.Services
{

    public class CityService
    {
        private readonly CitiesTranslateApiResponse _cities;
        private readonly Language _language;

        public CityService(Language language)
        {
            var jsonContent = File.ReadAllText($"https://alerts-history.oref.org.il/Shared/Ajax/GetDistricts.aspx?lang={language.ToString()}");// Todo: right lang code. 20/01/2025 Rafael
            _cities = JsonConvert.DeserializeObject<CitiesTranslateApiResponse>(jsonContent);
            _language = language;
        }

        public string GetCityNameByLanguage(string cityNameInHebrew, Language language)
        {
            var city = _cities.FirstOrDefault(c => c.Name == cityNameInHebrew);

            if (city == null)
                return cityNameInHebrew;

            return language switch
            {
                Language.English => city.Name_En,
                Language.Hebrew => city.Name,
                Language.Russian => city.Name_Ru,
                Language.Arabic => city.Name_Ar,
                _ => throw new NotSupportedException($"Language {language} is not supported.")
            };
        }
    }
}