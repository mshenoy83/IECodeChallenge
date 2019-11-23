using System;
using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class SimulationLoader
    {
        private readonly IPacmanTypeStrategy _pacmanStrategy;
        private PacmanType simulationType;

        public SimulationLoader(IPacmanTypeStrategy pacmanStrategy)
        {
            _pacmanStrategy = pacmanStrategy;
        }

        public void InitializeSimulation()
        {
            while (true)
            {
                Console.WriteLine("Type 1 to enter input via the console.");
                Console.WriteLine("Type 2 to enter input via a file.");

                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input....");
                    continue;
                }

                if(input.Equals("exit",StringComparison.InvariantCultureIgnoreCase))
                    return;

                if (IsValidInput(input))
                {
                    break;
                }

                Console.WriteLine("Invalid input....");
            }

            IPacmanService pacmanService = _pacmanStrategy.GetPacmanService(simulationType);
            pacmanService.Simulate();
        }

        private bool IsValidInput(string input)
        {
            if (!int.TryParse(input, out int selection))
            {
                return false;
            }

            switch (selection)
            {
                case 1:
                    simulationType = PacmanType.Console;
                    return true;
                case 2:
                    simulationType = PacmanType.FileUpload;
                    return true;
                default:
                    return false;
            }

        }
    }
}
