using System.Collections.Generic;
using IECodeChallenge.Services;
using Moq;

namespace IECodeChallenge.Test.Fixtures
{
    public class PacmanTypeStrategyFixture
    {
        public PacmanTypeStrategyFixture()
        {
            var mockCommandParser = new Mock<IPacmanCommandParser>();
            var mockPathFinder = new Mock<IPathFinder>();
            var mockReportGen = new Mock<IReportGenerator>();
            var mockConsoleService = new Mock<IConsoleService>();
            var pacmanConsoleService = new PacmanConsoleService(mockCommandParser.Object,
                mockPathFinder.Object, mockReportGen.Object, mockConsoleService.Object);
            var pacmanFileService = new PacmanFileParserService(mockCommandParser.Object,
                mockPathFinder.Object, mockReportGen.Object, mockConsoleService.Object);
            Service = new PacmanTypeStrategy(new List<IPacmanService> { pacmanConsoleService, pacmanFileService });
        }
        public IPacmanTypeStrategy Service { get; private set; }
    }
}
