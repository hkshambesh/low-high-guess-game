using GuessGame.ConsoleApp;
using GuessGame.ConsoleApp.GameModes;
using GuessGame.ConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using IGamePlayService = GuessGame.ConsoleApp.Interfaces.IGamePlayService;

// Setup dependency injection
var serviceProvider = new ServiceCollection()
    .AddSingleton<IGamePlayService, GamePlayService>()
    .AddSingleton<IGameModeFactory, GameModeFactory>()
    .AddTransient<INumberGuess, NumberGuess>()
    .AddTransient<IConsole, ConsoleService>()
    .AddTransient<ComputerGuess>()
    .AddTransient<PlayerGuess>()
    .BuildServiceProvider();
            
var gameService = serviceProvider.GetRequiredService<IGamePlayService>();
gameService.Start();