using GuessGame.ConsoleApp.Interfaces;

namespace GuessGame.ConsoleApp.GameModes
{
    public class NumberGuess : INumberGuess
    {
        public int Low { get; private set; }
        public int High { get; private set; }

        public int Guess()
        {
            var random = new Random();
            return random.Next(Low, High);
        }

        public void SetRange(int low, int high)
        {
            Low = low;
            High = high;
        }
    }
}