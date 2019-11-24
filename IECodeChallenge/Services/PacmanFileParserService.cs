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

        public PacmanFileParserService(IPacmanCommandParser pacmanCommandParser, IPathFinder pathfinder, IReportGenerator reportGenerator)
        {
            _pacmanCommandParser = pacmanCommandParser;
            _pathfinder = pathfinder;
            _reportGenerator = reportGenerator;
        }

        public PacmanType ServiceType => PacmanType.FileUpload;

        public void Simulate()
        {
            Console.WriteLine("Enter Filename :");
            while (true)
            {
                try
                {
                    string filename = Console.ReadLine();
                    _pacmanCommandParser.ParseFile(filename);
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Invalid argument. Please enter a valid filename.");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found. Please enter a valid filename.");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    return;
                }    
            }

            var pacmanModel = _pathfinder.UpdatePacmanPath(_pacmanCommandParser.GetCommandList());
            _reportGenerator.GeneratePacmanReport(pacmanModel);
            
        }
    }
}
