using GuessGame.ConsoleApp.Interfaces;

namespace GuessGame.ConsoleApp.GameModes
{
    public class ComputerGuess : IGameMode
    {
        private readonly INumberGuess _numberGuess;
        private readonly IConsole _console;

        public ComputerGuess(INumberGuess numberGuess, IConsole console)
        {
            _numberGuess = numberGuess;
            _console = console;
        }

        public void Play()
        {
            _console.WriteLine("Think of a number between 1 and 10,000.");
            
            _numberGuess.SetRange(1, 10000);

            int playerResponse;
            
            do
            {
                int computerGuess = _numberGuess.Guess();
                
                _console.WriteLine($"Is your number {computerGuess}? [1] too low, [2] too high, [3] correct");
                
                playerResponse = Convert.ToInt32(_console.ReadLine());
            
                switch (playerResponse)
                {
                    case 1:
                        _numberGuess.SetRange(computerGuess + 1, _numberGuess.High);
                        break;
                    case 2:
                        _numberGuess.SetRange(_numberGuess.Low, computerGuess - 1);
                        break;
                    default:
                        _console.WriteLine("Invalid Response. Try Again!");
                        break;
                }
            } while (playerResponse != 3);
        
            _console.WriteLine("Yay! I guessed your number. :-)");
        }
    }
}