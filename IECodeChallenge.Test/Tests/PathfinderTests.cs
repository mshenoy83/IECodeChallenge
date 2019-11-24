using FluentAssertions;
using IECodeChallenge.Models;
using IECodeChallenge.Test.Fixtures;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            private readonly PathFinderFixture ServiceFixture = new PathFinderFixture(TestType.Negative);

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

        public class PacmanDirectionTests
        {
            private readonly PathFinderFixture ServiceFixture = new PathFinderFixture();

            [Theory]
            [MemberData(nameof(TestDirectionData))]
            public void Direction_Should_Match_Expected_Result(TurnTaken turn, Direction currentDirection, bool isInGrid, Direction expectedDirection)
            {
                var actualDirection = ServiceFixture.Service.GetNewPacmanDirection(turn, currentDirection, isInGrid);
                actualDirection.Should().Be(expectedDirection);
            }

            #region TestData
            public static IEnumerable<object[]> TestDirectionData()
            {
                yield return new object[] { TurnTaken.LEFT, Direction.NORTH, true, Direction.EAST };
                yield return new object[] { TurnTaken.LEFT, Direction.EAST, true, Direction.SOUTH };
                yield return new object[] { TurnTaken.LEFT, Direction.WEST, true, Direction.NORTH };
                yield return new object[] { TurnTaken.LEFT, Direction.SOUTH, true, Direction.WEST };
                yield return new object[] { TurnTaken.RIGHT, Direction.NORTH, true, Direction.WEST };
                yield return new object[] { TurnTaken.RIGHT, Direction.EAST, true, Direction.NORTH };
                yield return new object[] { TurnTaken.RIGHT, Direction.WEST, true, Direction.SOUTH };
                yield return new object[] { TurnTaken.RIGHT, Direction.SOUTH, true, Direction.EAST };
                yield return new object[] { TurnTaken.LEFT, Direction.NORTH, false, Direction.NORTH };
                yield return new object[] { TurnTaken.LEFT, Direction.EAST, false, Direction.EAST };
                yield return new object[] { TurnTaken.LEFT, Direction.WEST, false, Direction.WEST };
                yield return new object[] { TurnTaken.LEFT, Direction.SOUTH, false, Direction.SOUTH };
                yield return new object[] { TurnTaken.RIGHT, Direction.NORTH, false, Direction.NORTH };
                yield return new object[] { TurnTaken.RIGHT, Direction.EAST, false, Direction.EAST };
                yield return new object[] { TurnTaken.RIGHT, Direction.WEST, false, Direction.WEST };
                yield return new object[] { TurnTaken.RIGHT, Direction.SOUTH, false, Direction.SOUTH };
            }
            #endregion
        }

        public class PacmanPositionTests
        {
            private readonly PathFinderFixture ServiceFixture = new PathFinderFixture();

            [Theory]
            [MemberData(nameof(TestDirectionData))]
            public void Position_Should_Match_Expected_Result(PacmanModel model, Point expectedPosition)
            {
                var actualPosition = ServiceFixture.Service.MovePacman(model);
                actualPosition.Should().Be(expectedPosition);
            }

            #region TestData
            public static IEnumerable<object[]> TestDirectionData()
            {
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(0,0),
                        DirectionFacing = Direction.WEST
                    },
                    new Point(0,0)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(0,0),
                        DirectionFacing = Direction.SOUTH
                    },
                    new Point(0,0)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(5,5),
                        DirectionFacing = Direction.EAST
                    },
                    new Point(5,5)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(5,5),
                        DirectionFacing = Direction.NORTH
                    },
                    new Point(5,5)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(5,0),
                        DirectionFacing = Direction.EAST
                    },
                    new Point(5,0)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(5,0),
                        DirectionFacing = Direction.SOUTH
                    },
                    new Point(5,0)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(0,5),
                        DirectionFacing = Direction.WEST
                    },
                    new Point(0,5)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(0,5),
                        DirectionFacing = Direction.NORTH
                    },
                    new Point(0,5)
                };
                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(0,5),
                        DirectionFacing = Direction.EAST
                    },
                    new Point(1,5)
                };

                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(0,5),
                        DirectionFacing = Direction.SOUTH
                    },
                    new Point(0,4)
                };

                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(2,3),
                        DirectionFacing = Direction.NORTH
                    },
                    new Point(2,4)
                };

                yield return new object[]
                {
                    new PacmanModel
                    {
                        Position = new Point(3,2),
                        DirectionFacing = Direction.WEST
                    },
                    new Point(2,2)
                };
            }
            #endregion
        }
    }
}
