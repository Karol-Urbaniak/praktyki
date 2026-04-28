using praktyki.Models;
using praktyki_vies;
using System.Net.Http.Json;

namespace praktyki.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "e7ddfffc1caa4cd4ab8121024262704";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            var url = $"https://api.weatherapi.com/v1/current.json?key={_apiKey}&q={city}&lang=pl";

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
