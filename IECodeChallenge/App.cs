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
    }
}
