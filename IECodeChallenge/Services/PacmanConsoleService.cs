using System;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanConsoleService : IPacmanService
    {
        private readonly IPacmanCommandParser _pacmanCommandParser;

        public PacmanConsoleService(IPacmanCommandParser pacmanCommandParser)
        {
            _pacmanCommandParser = pacmanCommandParser;
        }

        public void Simulate()
        {
            while (true)
            {
                _pacmanCommandParser.ParseCommand(Console.ReadLine());
            }
        }

        public PacmanType ServiceType => PacmanType.Console;
    }
}
