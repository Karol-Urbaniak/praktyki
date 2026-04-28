using System.Runtime.CompilerServices;
using praktyki.Commands;
public static class ConsoleExtensions
{
    public static bool HandleConsoleCommand(this IHost app, string[] args)
    {
        if (args.Length == 0) return false;

        using var scope = app.Services.CreateScope();
        if (args.Length > 0 && args[0] == "--verify-pesel")
        {
            var command = scope.ServiceProvider.GetRequiredService<VerifyPeselCommand>();
            command.Run(args);
            return true;
        }
        return false;
    }
}
