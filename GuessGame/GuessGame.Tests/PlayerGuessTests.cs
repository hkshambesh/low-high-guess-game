using GuessGame.ConsoleApp.GameModes;
using GuessGame.ConsoleApp.Interfaces;
using Moq;

namespace GuessGame.Tests;

public class PlayerGuessTests
{
    [Fact]
    public void ComputerGuessCorrect_When_GameIsPlayerMode()
    {
        // Arrange
        var mockNumber = new Mock<INumberGuess>();
        var mockConsole = new Mock<IConsole>();

        mockNumber.SetupGet(x => x.Low).Returns(1);
        mockNumber.SetupGet(x => x.High).Returns(10);
        mockNumber.Setup(x => x.Guess()).Returns(3);

        mockConsole.Setup(x => x.ReadLine()).Returns("3");

        // Act
        var actual = new PlayerGuess(mockNumber.Object, mockConsole.Object);
        actual.Play();

        // Assert
        mockConsole.Verify(x=>x.WriteLine("Correct! You won :-)"), Times.Once);
    }
}