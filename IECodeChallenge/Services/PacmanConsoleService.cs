using System;
using System.Collections.Generic;
using System.Text;

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

        }

        public PacmanType ServiceType => PacmanType.Console;
    }
}
