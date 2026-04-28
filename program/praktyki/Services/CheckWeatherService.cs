using Microsoft.Extensions.Options;
using praktyki.Models;
using praktyki_vies;
using System.Net.Http.Json;

namespace praktyki.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherSettings _settings;

        public WeatherService(HttpClient httpClient, IOptions<WeatherSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {

            var url = $"{_settings.WeatherBaseUrl}current.json?key={_settings.WeatherApiKey}&q={city}&lang=pl";
            
            
            try
            {
                return await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd pobierania pogody dla {city}: {ex.Message}");
                return null;
            }
        }
    }
}
