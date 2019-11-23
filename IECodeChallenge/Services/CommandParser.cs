using System;
using System.Collections.Generic;
using System.Linq;

namespace IECodeChallenge.Services
{
    public class CommandParser : ICommandParser
    {
        private readonly List<string> _validCommands = new List<string> { "PLACE", "MOVE", "LEFT", "RIGHT", "REPORT" };
        private readonly Queue<string> _commandQueue = new Queue<string>();
        private bool _commandQueueInitiated = false;

        public void ParseCommand(string input)
        {
            //TODO use regex
            var command = _validCommands.FirstOrDefault(x => x.Contains(input, StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrEmpty(command))
                return;

            //If its a place command, initiate/re-initiate the queue
            if (IsValidPlaceCommand(input))
            {
                _commandQueueInitiated = true;
                _commandQueue.Clear();
            }

            if (_commandQueueInitiated)
            {
                _commandQueue.Enqueue(command);
            }
        }

        public void ParseFile(string input)
        {

        }

        public List<string> GetCommandList()
        {
            _commandQueueInitiated = false;
            var commandList = new List<string>();
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
        public bool IsValidPlaceCommand(string input)
        {
            return input.Equals("PLACE");
        }

    }
}
