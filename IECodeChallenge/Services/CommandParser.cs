using System;


namespace IECodeChallenge.Services
{
    public class CommandParser : ICommandParser
    {
        public virtual string ParseCommand(string input)
        {
            if (input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                Environment.Exit(0);

            return input;
        }
    }
}
