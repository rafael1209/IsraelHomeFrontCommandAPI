using IsraelHomeFrontCommandAPI.Enums;
using IsraelHomeFrontCommandAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraelHomeFrontCommandAPI.Services
{

    public class CityService
    {
        private readonly List<City> _cities;

        public CityService(string filePath)
        {
            var jsonContent = File.ReadAllText(filePath);
            _cities = JsonConvert.DeserializeObject<List<City>>(jsonContent) ?? [];
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