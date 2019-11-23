using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanCommandParser : IPacmanCommandParser
    {
        private readonly Dictionary<string, CommandType> _validCommands = new Dictionary<string, CommandType>
        {
            {"PLACE",CommandType.PLACE},
            {"MOVE",CommandType.MOVE},
            {"LEFT",CommandType.LEFT},
            {"RIGHT",CommandType.RIGHT},
            {"REPORT",CommandType.REPORT}
        };
        private readonly Queue<KeyValuePair<CommandType, string>> _commandQueue = new Queue<KeyValuePair<CommandType, string>>();
        private bool _commandQueueInitiated;

        public void ParseCommand(string input)
        {


            //TODO use regex
            var command = FetchCommand(input);
            if (string.IsNullOrEmpty(command.Value))
                return;

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
        }

        public void ParseFile(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));

            if (!File.Exists(input))
                throw new FileNotFoundException("Input file does not exist.");

            using (var reader = new StreamReader(File.OpenRead(input)))
            {
                ParseCommand(reader.ReadLine());
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

        /// <summary>
        /// TODO use regex
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public KeyValuePair<CommandType, string> FetchCommand(string input)
        {
            string command = _validCommands.Keys.FirstOrDefault(x => x.Contains(input, StringComparison.InvariantCultureIgnoreCase));
            return string.IsNullOrWhiteSpace(command) ? new KeyValuePair<CommandType, string>()
                : new KeyValuePair<CommandType, string>(_validCommands[command], command);
        }

        public PlacementModel ParsePlaceCommand(string input)
        {
            input = input.ToUpperInvariant().Replace("PLACE", "").Trim();
            string[] strList = input.Split(",");
            var model = new PlacementModel();
            if (Enum.TryParse(strList[2], out Direction direction))
            {
                model.DirectionFacing = direction;
            }

            if (int.TryParse(strList[0], out int xPos))
            {
                model.XPosition = xPos;
            }

            if (int.TryParse(strList[1], out int yPos))
            {
                model.YPosition = yPos;
            }

            return model;
        }




    }
}
