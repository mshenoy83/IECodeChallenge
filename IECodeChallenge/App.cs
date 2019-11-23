using System;
using IECodeChallenge.Services;

namespace IECodeChallenge
{
    public class App
    {
        private readonly ICommandParser _commandParser;

        public App(ICommandParser commandParser)
        {
            _commandParser = commandParser;
        }

        public void Start()
        {
            while (true)
            {
                string input = Console.ReadLine();
                _commandParser.ParseCommand(input);
                if (_commandParser.IsReportCommand)
                {

                }
            }
        }
    }
}
