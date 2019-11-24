using System;
using System.Collections.Generic;
using FluentAssertions;
using IECodeChallenge.Models;
using IECodeChallenge.Services;
using IECodeChallenge.Test.Fixtures;
using Xunit;

namespace IECodeChallenge.Test.UnitTests
{
    public class PacmanTypeStrategyTests
    {
        private readonly PacmanTypeStrategyFixture _serviceFixture = new PacmanTypeStrategyFixture();

        [Theory]
        [MemberData(nameof(TestStrategyRequestData))]
        public void ValidateStrategyResponse(PacmanType pacmanType, Type expectedType)
        {
            var service = _serviceFixture.Service.GetPacmanService(pacmanType);
            service.Should().BeOfType(expectedType);
        }

        #region TestData
        public static IEnumerable<object[]> TestStrategyRequestData()
        {
            yield return new object[] { PacmanType.Console, typeof(PacmanConsoleService)};
            yield return new object[] { PacmanType.FileUpload, typeof(PacmanFileParserService) };
        }
        #endregion
    }
}
