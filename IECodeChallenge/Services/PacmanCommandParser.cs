using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IECodeChallenge.Services
{
    public class PacmanCommandParser : IPacmanCommandParser
    {
        private readonly List<string> _validCommands = new List<string> { "PLACE", "MOVE", "LEFT", "RIGHT", "REPORT" };
        private readonly Queue<string> _commandQueue = new Queue<string>();
        private bool _commandQueueInitiated;

        public void ParseCommand(string input)
        {
            //TODO use regex
            string command = _validCommands.FirstOrDefault(x => x.Contains(input, StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrEmpty(command))
                return;

            //If its a place command, initiate/re-initiate the queue
            if (IsValidPlaceCommand(input))
            {
                isreportCommand = false;
                _commandQueueInitiated = true;
                _commandQueue.Clear();
            }

            if (_commandQueueInitiated)
            {
                _commandQueue.Enqueue(command);

                if (command.Equals("REPORT", StringComparison.InvariantCultureIgnoreCase))
                {
                    isreportCommand = true;
                }
            }
        }

        public void ParseFile(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));

            if(!File.Exists(input))
                throw new FileNotFoundException("Input file does not exist.");

            using (var reader = new StreamReader(File.OpenRead(input)))
            {
                ParseCommand(reader.ReadLine());
            }
        }

        private bool isreportCommand;

        public bool IsReportCommand => isreportCommand;

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
