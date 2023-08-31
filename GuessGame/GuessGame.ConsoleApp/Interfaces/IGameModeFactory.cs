using GuessGame.ConsoleApp.Models;

namespace GuessGame.ConsoleApp.Interfaces
{
    public interface IGameModeFactory
    {
        IGameMode CreateGameMode(GameModeChoice choice);
    }
}