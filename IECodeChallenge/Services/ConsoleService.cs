using System;

namespace IECodeChallenge.Services
{
    public class ConsoleService : IConsoleService
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string messageTemplate, params object[] args)
        {
            Console.WriteLine(messageTemplate, args);
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
