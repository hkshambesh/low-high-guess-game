using GuessGame.ConsoleApp.Interfaces;

namespace GuessGame.ConsoleApp;

public class ConsoleService : IConsole
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}