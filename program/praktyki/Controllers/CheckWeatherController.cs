using Microsoft.AspNetCore.Mvc;
using praktyki.Models;
using praktyki.Services;
namespace praktyki_vies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckWeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;


        public CheckWeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetViesData(string city)
        {
            var result = await _weatherService.GetWeatherAsync(city);

            if (result == null) return NotFound("Serwis WeatherAPI nie zwrócił danych.");
            return Ok(result);

        }

    }
}