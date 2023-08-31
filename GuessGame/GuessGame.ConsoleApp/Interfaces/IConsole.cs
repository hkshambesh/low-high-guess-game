namespace GuessGame.ConsoleApp.Interfaces;

public interface IConsole
{
    void WriteLine(string message);
    string? ReadLine();
}