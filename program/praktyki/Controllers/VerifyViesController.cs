using Microsoft.AspNetCore.Mvc;

namespace praktyki_vies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerifyViesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        
        public VerifyViesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{countryCode}/vat/{taxId}")]
        public async Task<IActionResult> GetViesData(string countryCode, string taxId)
        {
            var url = $"https://ec.europa.eu/taxation_customs/vies/rest-api/ms/{countryCode}/vat/{taxId}";

            try
            {
                // Pobieramy dane i zamieniamy JSON na naszą klasę
                var result = await _httpClient.GetFromJsonAsync<VerifyVies>(url);

                if (result == null)
                    return NotFound("Serwis VIES nie zwrócił danych.");

                // Zwracamy cały obiekt do Twojego GUI / Curla
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Błąd komunikacji: {ex.Message}");
            }
        }

    }
}