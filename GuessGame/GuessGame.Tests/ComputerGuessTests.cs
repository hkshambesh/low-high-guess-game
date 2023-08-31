using GuessGame.ConsoleApp.GameModes;
using GuessGame.ConsoleApp.Interfaces;
using Moq;

namespace GuessGame.Tests;

public class ComputerGuessTests
{
    [Fact]
    public void PlayerGuessCorrect_When_GameIsComputerMode()
    {
        // Arrange
        var mockNumber = new Mock<INumberGuess>();
        var mockConsole = new Mock<IConsole>();

        mockNumber.Setup(x => x.SetRange(1, 10));
        mockNumber.Setup(x => x.Guess()).Returns(3);

        mockConsole.Setup(x => x.ReadLine()).Returns("3");

        // Act
        var actual = new ComputerGuess(mockNumber.Object, mockConsole.Object);
        actual.Play();

        // Assert
        mockConsole.Verify(x=>x.WriteLine("Yay! I guessed your number. :-)"), Times.Once);
    }
}