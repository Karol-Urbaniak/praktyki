using Microsoft.AspNetCore.Mvc;
using praktyki.Models;
using praktyki.Services;
namespace praktyki_vies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerifyViesController : ControllerBase
    {
        private readonly ViesService _viesService;

        
        public VerifyViesController(ViesService viesService)
        {
            _viesService = viesService;
        }

        [HttpGet("{countryCode}/vat/{taxId}")]
        public async Task<IActionResult> GetViesData(string countryCode, string taxId)
        {
            var result = await _viesService.GetViesDataAsync(countryCode, taxId);

                if (result == null) return NotFound("Serwis VIES nie zwrócił danych.");
                return Ok(result);

        }

    }
}