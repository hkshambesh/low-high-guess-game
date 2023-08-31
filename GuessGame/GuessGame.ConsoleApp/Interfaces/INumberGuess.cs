namespace GuessGame.ConsoleApp.Interfaces
{
    public interface INumberGuess
    {
        int Low { get; }
        int High { get; }
        int Guess();
        void SetRange(int low, int high);
    }
}