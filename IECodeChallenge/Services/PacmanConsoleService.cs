using System;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanConsoleService : IPacmanService
    {
        private readonly IPacmanCommandParser _pacmanCommandParser;
        private readonly IPathFinder _pathfinder;
        private readonly IReportGenerator _reportGenerator;

        public PacmanConsoleService(IPacmanCommandParser pacmanCommandParser, IPathFinder pathfinder, IReportGenerator reportGenerator)
        {
            _pacmanCommandParser = pacmanCommandParser;
            _pathfinder = pathfinder;
            _reportGenerator = reportGenerator;
        }

        public void Simulate()
        {
            while (true)
            {
                _pacmanCommandParser.ParseCommand(Console.ReadLine());
                if (_pacmanCommandParser.IsReportCommand)
                {
                    break;
                }
            }

            var pacmanModel = _pathfinder.UpdatePacmanPath(_pacmanCommandParser.GetCommandList());
            _reportGenerator.GeneratePacmanReport(pacmanModel);
        }

        public PacmanType ServiceType => PacmanType.Console;
    }
}
