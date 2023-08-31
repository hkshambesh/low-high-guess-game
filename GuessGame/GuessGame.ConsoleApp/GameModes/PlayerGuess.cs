using GuessGame.ConsoleApp.Interfaces;

namespace GuessGame.ConsoleApp.GameModes
{
    public class PlayerGuess : IGameMode
    {
        private readonly INumberGuess _numberGuess;
        private readonly IConsole _console;

        public PlayerGuess(INumberGuess numberGuess, IConsole console)
        {
            _numberGuess = numberGuess;
            _console = console;
        }

        public void Play()
        {
            _console.WriteLine("Guess my number between 1 and 10,000.");
            
            _numberGuess.SetRange(1, 10000);

            int computerSecretNumber = _numberGuess.Guess();
            
            while (true)
            {
                _console.WriteLine("Enter your guess: ");
                int userGuess = Convert.ToInt32(_console.ReadLine());

                if (userGuess < computerSecretNumber)
                {
                    _console.WriteLine("Too low");
                }
                else if (userGuess > computerSecretNumber)
                {
                    _console.WriteLine("Too high");
                }
                else if (userGuess > _numberGuess.High || userGuess < _numberGuess.Low)
                {
                    _console.WriteLine("number MUST be between 1 and 10,000.");
                }
                else 
                {
                    _console.WriteLine("Correct! You won :-)");
                    break;
                }
            }
        }
    }
}