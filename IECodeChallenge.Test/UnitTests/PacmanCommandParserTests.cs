using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using IECodeChallenge.Models;
using IECodeChallenge.Services;

using Xunit;

namespace IECodeChallenge.Test.UnitTests
{
    public class PacmanCommandParserTests
    {
        [Theory]
        [MemberData(nameof(ParseCommandValidationsData))]
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

        #region ParseCommand TestData
        public static IEnumerable<object[]> ParseCommandValidationsData()
        {
            yield return new object[] { new List<string>
            {
                "PLACE 1,2,EAST",
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "RIGHT",
                "REPORT"
            },
                7,3,1,1
            };
            yield return new object[] { new List<string>
            {
                "PLACE 1,2,EAST",
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "PLACE 1,2,EAST",
                "REPORT"
            },
                2,0,0,0
            };

            yield return new object[] { new List<string>
            {
                "PLACE 1,2,EASTEY",
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT"
            },
                0,0,0,0
            };
        }
        #endregion

        [Theory]
        [InlineData(@"C:\Somefile.txt")]
        [InlineData(@"A:\Somefile.txt")]
        public void FileNotFoundParseFileCheck(string filename)
        {
            var commandparser = new PacmanCommandParser();
            Action act = () => commandparser.ParseFile(filename);
            act.Should().ThrowExactly<FileNotFoundException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void InvalidArgumentParseFileCheck(string filename)
        {
            var commandparser = new PacmanCommandParser();
            Action act = () => commandparser.ParseFile(filename);
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(ParseFileValidationsData))]
        public void ValidateParseFile(string filename,int commandCount,int moveCount,int leftCount,int rightCount)
        {
            var commandparser = new PacmanCommandParser();
            commandparser.ParseFile(filename);

            var commandList = commandparser.GetCommandList();
            commandList.Count.Should().Be(commandCount);
            commandList.Count(x => x.Key == CommandType.MOVE).Should().Be(moveCount);
            commandList.Count(x => x.Key == CommandType.LEFT).Should().Be(leftCount);
            commandList.Count(x => x.Key == CommandType.RIGHT).Should().Be(rightCount);
        }

        #region ParseFile TestData
        public static IEnumerable<object[]> ParseFileValidationsData()
        {
            yield return new object[] { Path.Combine(Directory.GetCurrentDirectory(),"ParseFiles\\Inputfile1.txt"),
                12,6,2,1
            };
            yield return new object[] { Path.Combine(Directory.GetCurrentDirectory(),"ParseFiles\\Inputfile2.txt"),
                2,0,0,0
            };

            yield return new object[] { Path.Combine(Directory.GetCurrentDirectory(),"ParseFiles\\Inputfile3.txt"),
                0,0,0,0
            };
        }
        #endregion
        
    }
}
