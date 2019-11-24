using System;

namespace IECodeChallenge.Services
{
    public class ConsoleService : IConsoleService
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Writeline(string messageTemplate, params object[] args)
        {
            Console.WriteLine(messageTemplate, args);
        }
    }
}
