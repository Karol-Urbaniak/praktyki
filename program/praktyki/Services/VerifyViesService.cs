using praktyki.Models;
using praktyki_vies;
using System.Net.Http.Json;

namespace praktyki.Services
{
    public class ViesService
    {
        private readonly HttpClient _httpClient;

        public ViesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<VerifyVies?> GetViesDataAsync(string countryCode, string taxId)
        {
            var url = $"https://ec.europa.eu/taxation_customs/vies/rest-api/ms/{countryCode}/vat/{taxId}";

            try
            {
                return await _httpClient.GetFromJsonAsync<VerifyVies>(url);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}