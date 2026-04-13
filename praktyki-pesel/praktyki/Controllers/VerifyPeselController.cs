using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace praktyki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyPeselController : ControllerBase
    {
        [HttpGet("{Number}")]
        public ActionResult<VerifyPeselResponse> Verify(string Number)
        {
            if (string.IsNullOrEmpty(Number) || Number.Length != 11)
            {
                return BadRequest(new VerifyPeselResponse
                {
                    IsValid = false,
                    Message = "PESEL musi mieć 11 znaków."
                });
            }
            int sum = (int.Parse(Number[0].ToString()) * 1) +
                      (int.Parse(Number[1].ToString()) * 3) +
                      (int.Parse(Number[2].ToString()) * 7) +
                      (int.Parse(Number[3].ToString()) * 9) +
                      (int.Parse(Number[4].ToString()) * 1) +
                      (int.Parse(Number[5].ToString()) * 3) +
                      (int.Parse(Number[6].ToString()) * 7) +
                      (int.Parse(Number[7].ToString()) * 9) +
                      (int.Parse(Number[8].ToString()) * 1) +
                      (int.Parse(Number[9].ToString()) * 3);
            int remainder = sum % 10;
            int checkDigit = 10 - remainder;
            if (checkDigit == 10)
            {
                checkDigit = 0;
            }
            int lastDigit = int.Parse(Number[10].ToString());

            if (checkDigit != lastDigit)
            {
                return BadRequest(new VerifyPeselResponse
                {
                    IsValid = false,
                    Message = "Cyfra kontrolna się nie zgadza - PESEL jest niepoprawny"
                });
            }
            return Ok(VerifyPeselProcess(Number));
            
        }

            private VerifyPeselResponse VerifyPeselProcess(string pesel)
            {
            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            if (month > 20 && month < 33)
            {
                year += 2000;
                month -= 20;
            }
            else
            {
                year += 1900;
                month -= 20;
            }
            int lastChar = int.Parse(pesel[9].ToString());

            string gender;
            if (lastChar % 2 == 0)
            {
                gender = "K";
            }  else
            {
                gender = "M";
            }
            //string gender = ( % 2 == 0) ? "Kobieta" : "Mężczyzna";

            return new VerifyPeselResponse
            {
                IsValid = true,
                BrithDate = $"{day}-{month}-{year}",
                Gender = gender,
                Message = "Dane wygenerowane pomyślnie."
            };
            }
            
        }
    }
