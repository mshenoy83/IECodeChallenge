using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }
    }
}
