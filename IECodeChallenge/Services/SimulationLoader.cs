using System;
using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class SimulationLoader
    {
        private readonly IPacmanTypeStrategy _pacmanStrategy;
        private PacmanType simulationType;
        private readonly ICommandParser _commandParser;
        private readonly IConsoleService _consoleService;

        public SimulationLoader(IPacmanTypeStrategy pacmanStrategy, 
                                ICommandParser commandParser,
                                IConsoleService consoleService)
        {
            _consoleService = consoleService;
            _pacmanStrategy = pacmanStrategy;
            _commandParser = commandParser;
        }

        public void InitializeSimulation()
        {
            while (true)
            {
                Console.WriteLine("Type 1 to enter input via the console.");
                Console.WriteLine("Type 2 to enter input via a file.");

                if (IsValidInput(_commandParser.ParseCommand(_consoleService.ReadLine())))
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
