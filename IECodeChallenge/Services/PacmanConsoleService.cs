using System;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanConsoleService : IPacmanService
    {
        private readonly IPacmanCommandParser _pacmanCommandParser;
        private readonly IPathFinder _pathfinder;
        private readonly IReportGenerator _reportGenerator;
        private readonly IConsoleService _consoleService;

        public PacmanConsoleService(IPacmanCommandParser pacmanCommandParser, 
                                    IPathFinder pathfinder, 
                                    IReportGenerator reportGenerator,
                                    IConsoleService consoleService)
        {
            _consoleService = consoleService;
            _pacmanCommandParser = pacmanCommandParser;
            _pathfinder = pathfinder;
            _reportGenerator = reportGenerator;
        }

        public void Simulate()
        {
            Console.WriteLine("You can start typing the commands now :");
            while (true)
            {
                _pacmanCommandParser.ParseCommand(_consoleService.ReadLine());
                if (_pacmanCommandParser.IsReportRequested)
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
