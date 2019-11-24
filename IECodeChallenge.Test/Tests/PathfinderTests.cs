using FluentAssertions;
using IECodeChallenge.Models;
using IECodeChallenge.Test.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IECodeChallenge.Test.Tests
{
    public class PathfinderTests
    {
        public class When_PlaceCommand_ReturnsNull
        {
            private readonly PathFinderFixture ServiceFixture = new PathFinderFixture(TestType.Negative, true);

            [Theory]
            [MemberData(nameof(TestInvalidPlaceCommandData))]
            public void UpdatePath_Should_Return_Null(List<KeyValuePair<CommandType, string>> commands)
            {
                var model = ServiceFixture.Service.UpdatePacmanPath(commands);
                model.Should().BeNull();
            }

            #region TestData
            public static IEnumerable<object[]> TestInvalidPlaceCommandData()
            {
                yield return new object[] { new List<KeyValuePair<CommandType, string>>
                    {
                        new KeyValuePair<CommandType, string>(CommandType.PLACE,"PLACE 1,2,WEST"),
                        new KeyValuePair<CommandType, string>(CommandType.MOVE,"MOVE"),
                        new KeyValuePair<CommandType, string>(CommandType.LEFT,"LEFT"),
                        new KeyValuePair<CommandType, string>(CommandType.REPORT,"REPORT")
                    }
                };
            }
            #endregion
        }

        public class When_NoCommands_AreParsed
        {
            private readonly PathFinderFixture ServiceFixture = new PathFinderFixture(TestType.Negative, true);

            [Theory]
            [MemberData(nameof(TestEmptyCommandList))]
            public void UpdatePath_Should_Return_Null(List<KeyValuePair<CommandType, string>> commands)
            {
                var model = ServiceFixture.Service.UpdatePacmanPath(commands);
                model.Should().BeNull();
            }

            #region TestData
            public static IEnumerable<object[]> TestEmptyCommandList()
            {
                yield return new object[] { new List<KeyValuePair<CommandType, string>>() };
            }
            #endregion
        }
    }
}
