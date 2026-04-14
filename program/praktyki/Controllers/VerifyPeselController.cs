using Microsoft.AspNetCore.Mvc;
using praktyki.Models;
using praktyki.Services;

namespace praktyki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyPeselController : ControllerBase
    {
        private readonly VerifyPeselService _VerifyPeselService = new VerifyPeselService();

        [HttpGet("{peselInput}")]
        public ActionResult<VerifyPeselResponse> Verify(string peselInput)
        {
            if (string.IsNullOrEmpty(peselInput) || peselInput.Length != 11)
            {
                return BadRequest(new VerifyPeselResponse
                {
                    IsValid = false,
                    Message = "PESEL musi mieć 11 znaków."
                });
            }

            if (!_VerifyPeselService.VerifyCheckSum(peselInput))
            {
                return BadRequest(new VerifyPeselResponse
                {
                    IsValid = false,
                    Message = "Cyfra kontrolna się nie zgadza - PESEL jest niepoprawny"
                });
            }

            var result = _VerifyPeselService.GetPeselData(peselInput);
            return Ok(result);
        }
    }
}