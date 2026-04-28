using praktyki.Services;

namespace praktyki.Commands
{
    public class VerifyPeselCommand
    {
        private readonly VerifyPeselService _peselService;

        public VerifyPeselCommand(VerifyPeselService peselSerivce)
        {
            _peselService = peselSerivce;
        }

        public void Run(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Błąd: Podaj PESEL jako drugi argument.");
                return;
            }

            string pesel = args[1];
            bool isCheckSumOk = _peselService.VerifyCheckSum(pesel);

            if (isCheckSumOk)
            {
                var data = _peselService.GetPeselData(pesel);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"PESEL: {pesel} jest POPRAWNY.");
                Console.WriteLine($"Data urodzenia: {data.BirthDate}");
                Console.WriteLine($"Płeć: {data.Gender}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"PESEL: {pesel} jest BŁĘDNY - suma kontrolna się nie zgadza");
            }
            Console.ResetColor();
        }
    }
}
