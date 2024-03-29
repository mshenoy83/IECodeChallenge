﻿using IECodeChallenge.Models;
using IECodeChallenge.Services;
using Moq;

namespace IECodeChallenge.Test.Fixtures
{
    public class PathFinderFixture
    {
        public PathFinderFixture(TestType testtype = TestType.Positive, bool useMock = true)
        {
            var mockCommandParser = new Mock<IPacmanCommandParser>();
            var setup = mockCommandParser.Setup(x => x.ParsePlaceCommand(It.IsAny<string>()));

            switch (testtype)
            {
                case TestType.Negative:
                    setup.Returns(() => null);
                    break;
                default:
                    setup.Returns(() => new PacmanModel());
                    break;
            }

            if (useMock)
            {
                Service = new PathFinder(mockCommandParser.Object);
            }
            else
            {
                Service = new PathFinder(new PacmanCommandParser());
            }

        }
        public IPathFinder Service { get; private set; }
    }

    public enum TestType
    {
        Positive,
        Negative
    }
}
