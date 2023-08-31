using GuessGame.ConsoleApp.Interfaces;
using GuessGame.ConsoleApp.Models;

namespace GuessGame.ConsoleApp;

public class GamePlayService : IGamePlayService
{
    private readonly IGameModeFactory _gameModeFactory;
    private readonly IConsole _console;

    public GamePlayService(IGameModeFactory gameModeFactory, IConsole console)
    {
        _gameModeFactory = gameModeFactory;
        _console = console;
    }

    public void Start()
    {
        _console.WriteLine("Welcome to Guess Game");
        _console.WriteLine("Choose a game mode: [1] Computer guesses your number [2] You guess the computer's number");
            
        var gameModeChoice = (GameModeChoice)Convert.ToInt32(Console.ReadLine());

        try
        {
            IGameMode gameMode = _gameModeFactory.CreateGameMode(gameModeChoice);
            gameMode.Play();
        }
        catch (Exception ex)
        {
            _console.WriteLine("Something went wrong. Please try again!");
        }
    }
}