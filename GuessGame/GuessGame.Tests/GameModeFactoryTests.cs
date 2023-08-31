using GuessGame.ConsoleApp.GameModes;
using GuessGame.ConsoleApp.Interfaces;
using GuessGame.ConsoleApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GuessGame.Tests;

public class GameModeFactoryTests
{
    private readonly GameModeFactory _gameModeFactory;

    public GameModeFactoryTests()
    {
        // Setup dependency injection for testing
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddTransient<INumberGuess, NumberGuess>()
            .AddTransient<ComputerGuess>()
            .AddTransient<PlayerGuess>()
            .AddSingleton<GameModeFactory>()
            .BuildServiceProvider();

        _gameModeFactory = serviceProvider.GetRequiredService<GameModeFactory>();
    }

    [Fact]
    public void CreateGameMode_Returns_ComputerGuess_When_Choice_Is_One()
    {
        // Arrange
        var gameMode = (GameModeChoice)Convert.ToInt32("1");
        
        // Act
        var actual = _gameModeFactory.CreateGameMode(gameMode);
        
        // Assert
        Assert.IsType<ComputerGuess>(actual);
    }
    
    [Fact]
    public void CreateGameMode_Returns_PlayerGuess_When_Choice_Is_Two()
    {
        // Arrange
        var gameMode = (GameModeChoice)Convert.ToInt32("2");
        
        // Act
        var actual = _gameModeFactory.CreateGameMode(gameMode);
        
        // Assert
        Assert.IsType<PlayerGuess>(actual);
    }
    
    [Fact]
    public void CreateGameMode_ThrowsException_When_Choice_Is_Invalid()
    {
        // Arrange
        var gameMode = (GameModeChoice)Convert.ToInt32("987");
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _gameModeFactory.CreateGameMode(gameMode));
    }
}