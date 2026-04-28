using praktyki.Models;

namespace praktyki.Services
{
    public class VerifyPeselService
    {
        public bool VerifyCheckSum(string pesel)
        {
            if (pesel.Length != 11 || !long.TryParse(pesel, out _)) return false;

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(pesel[i].ToString()) * weights[i];
            }

            int remainder = sum % 10;
            int checkDigit = (10 - remainder) % 10;

            int lastDigit = int.Parse(pesel[10].ToString());

            return checkDigit == lastDigit;
        }

        public VerifyPeselResponse GetPeselData(string pesel)
        {
            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            if (month > 80 && month < 93) { year += 1800; month -= 80; }
            else if (month > 0 && month < 13) { year += 1900; }
            else if (month > 20 && month < 33) { year += 2000; month -= 20; }
            else if (month > 40 && month < 53) { year += 2100; month -= 40; }
            else if (month > 60 && month < 73) { year += 2200; month -= 60; }

            int genderDigit = int.Parse(pesel[9].ToString());
            string gender;
            if (genderDigit % 2 == 0)
            {
                gender = "K";
            }
            else
            {
                gender = "M";
            }


            return new VerifyPeselResponse
            {
                IsValid = true,
                BirthDate = $"{day}-{month}-{year}",
                Gender = gender,
                Message = "Dane wygenerowane pomyślnie."
            };
        }
    }
}
