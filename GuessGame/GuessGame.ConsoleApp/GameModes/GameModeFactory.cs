using System;
using GuessGame.ConsoleApp.Interfaces;
using GuessGame.ConsoleApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GuessGame.ConsoleApp.GameModes
{
    public class GameModeFactory : IGameModeFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public GameModeFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGameMode CreateGameMode(GameModeChoice choice)
        {
            switch (choice)
            {
                case GameModeChoice.Computer:
                    return _serviceProvider.GetRequiredService<ComputerGuess>();
                case GameModeChoice.Player:
                    return _serviceProvider.GetRequiredService<PlayerGuess>();
                default:
                    throw new ArgumentOutOfRangeException($"Invalid Game Mode. {choice}");
            }
        }
    }
}