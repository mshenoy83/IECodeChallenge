using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanCommandParser : CommandParser, IPacmanCommandParser
    {
        private readonly Dictionary<string, CommandType> _validCommands = new Dictionary<string, CommandType>
        {
            {@"^(PLACE)\s-?\d+,{1}-?\d+,{1}(NORTH|SOUTH|WEST|EAST)",CommandType.PLACE},
            {@"^MOVE",CommandType.MOVE},
            {@"^LEFT",CommandType.LEFT},
            {@"^RIGHT",CommandType.RIGHT},
            {@"^REPORT",CommandType.REPORT}
        };
        private readonly Queue<KeyValuePair<CommandType, string>> _commandQueue = new Queue<KeyValuePair<CommandType, string>>();
        private bool _commandQueueInitiated;

        public override string ParseCommand(string input)
        {
            var parsedInput = base.ParseCommand(input);
            var command = FetchCommand(parsedInput);
            if (string.IsNullOrEmpty(command.Value))
                return input;

            //If its a place command, initiate/re-initiate the queue
            switch (command.Key)
            {
                case CommandType.PLACE:
                    isreportCommand = false;
                    _commandQueueInitiated = true;
                    _commandQueue.Clear();
                    _commandQueue.Enqueue(command);
                    break;
                default:
                    if (_commandQueueInitiated)
                    {
                        _commandQueue.Enqueue(command);
                    }
                    break;
            }

            if (command.Key == CommandType.REPORT)
            {
                isreportCommand = true;
            }

            return parsedInput;
        }

        public void ParseFile(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));

            if (!File.Exists(input))
                throw new FileNotFoundException("Input file does not exist.");

            using (var reader = new StreamReader(File.OpenRead(input)))
            {
                while (!reader.EndOfStream)
                {
                    ParseCommand(reader.ReadLine());    
                }
            }
        }

        private bool isreportCommand;

        public bool IsReportCommand => isreportCommand;

        public List<KeyValuePair<CommandType, string>> GetCommandList()
        {
            _commandQueueInitiated = false;
            var commandList = new List<KeyValuePair<CommandType, string>>();
            while (_commandQueue.Any())
            {
                commandList.Add(_commandQueue.Dequeue());
            }

            return commandList;
        }

        public KeyValuePair<CommandType, string> FetchCommand(string input)
        {
            foreach (KeyValuePair<string, CommandType> cmd in _validCommands)
            {
                if (Regex.Match(input.ToUpperInvariant(), cmd.Key).Success)
                {
                    return new KeyValuePair<CommandType, string>(cmd.Value, input);
                }
            }

            return new KeyValuePair<CommandType, string>();
        }

        public PacmanModel ParsePlaceCommand(string input)
        {
            string[] strList = input.ToUpperInvariant().Replace("PLACE", "").Trim().Split(",");
            
            if (!Enum.TryParse(strList[2].ToUpperInvariant(), out Direction direction))
            {
                return null;
            }

            if (!int.TryParse(strList[0], out int xPos))
            {
                return null;
            }

            if (!int.TryParse(strList[1], out int yPos))
            {
                return null;
            }

            return new PacmanModel
            {
                DirectionFacing = direction,
                Position = new Point(xPos, yPos)
            };

        }




    }
}
