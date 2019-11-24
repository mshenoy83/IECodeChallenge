using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using IECodeChallenge.Models;
using IECodeChallenge.Services;

namespace IECodeChallenge.Test.UnitTests
{
    public class PacmanCommandParserTests
    {
        public void ParseCommandValidations(List<string> commands,int commandCount,int moveCount,int leftCount,int rightCount)
        {
            var commandparser = new PacmanCommandParser();
            foreach (var cmd in commands)
            {
                commandparser.ParseCommand(cmd);
            }

            var commandList = commandparser.GetCommandList();
            commandList.Count.Should().Be(commandCount);
            commandList.Count(x => x.Key == CommandType.MOVE).Should().Be(moveCount);
            commandList.Count(x => x.Key == CommandType.LEFT).Should().Be(leftCount);
            commandList.Count(x => x.Key == CommandType.RIGHT).Should().Be(rightCount);
        }

        #region TestData
        public static IEnumerable<object[]> ParseCommandValidationsData()
        {
            yield return new object[] { PacmanType.Console, typeof(PacmanConsoleService) };
            yield return new object[] { PacmanType.FileUpload, typeof(PacmanFileParserService) };
        }
        #endregion
    }
}
