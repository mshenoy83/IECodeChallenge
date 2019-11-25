using System;
using System.IO;
using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanFileParserService : IPacmanService
    {
        private readonly IPacmanCommandParser _pacmanCommandParser;
        private readonly IPathFinder _pathfinder;
        private readonly IReportGenerator _reportGenerator;
        private readonly IConsoleService _consoleService;

        public PacmanFileParserService(IPacmanCommandParser pacmanCommandParser,
                                       IPathFinder pathfinder,
                                       IReportGenerator reportGenerator,
                                       IConsoleService consoleService)
        {
            _consoleService = consoleService;
            _pacmanCommandParser = pacmanCommandParser;
            _pathfinder = pathfinder;
            _reportGenerator = reportGenerator;
        }

        public PacmanType ServiceType => PacmanType.FileUpload;

        public void Simulate()
        {
            _consoleService.WriteLine("Enter Filename :");
            while (true)
            {
                try
                {
                    string filename = _consoleService.ReadLine();
                    _pacmanCommandParser.ParseFile(filename);
                    break;
                }
                catch (ArgumentNullException)
                {
                    _consoleService.WriteLine("Invalid argument. Please enter a valid filename.");
                }
                catch (FileNotFoundException)
                {
                    _consoleService.WriteLine("File not found. Please enter a valid filename.");
                }
                catch (Exception exception)
                {
                    _consoleService.WriteLine(exception.ToString());
                    return;
                }
            }

            var pacmanModel = _pathfinder.UpdatePacmanPath(_pacmanCommandParser.GetCommandList());
            if (_pacmanCommandParser.IsReportRequested)
            {
                _reportGenerator.GeneratePacmanReport(pacmanModel);
            }

        }
    }
}
