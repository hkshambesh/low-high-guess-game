using GuessGame.ConsoleApp.GameModes;

namespace GuessGame.Tests;

public class NumberGuessTests
{
    [Fact]
    public void LowHigh_Number_BySetRange()
    {
        // Arrange
        int low = 1;
        int high = 10;
        
        var guesser = new NumberGuess();
        guesser.SetRange(low, high);

        // Act, Assert
        Assert.Equal(guesser.Low, low);
        Assert.Equal(guesser.High, high);
    }
    
    [Fact]
    public void GuessNumber_Generated_Within_SetRange()
    {
        // Arrange
        int low = 1;
        int high = 10;
        
        var guesser = new NumberGuess();
        guesser.SetRange(low, high);

        // Act
        var number = guesser.Guess();
        
        // Assert
        Assert.True(number <= guesser.High && number >= guesser.Low);
    }
    
}