using System;

namespace IECodeChallenge.Services
{
    public interface IConsoleService
    {
        string ReadLine();
        void WriteLine(string messageTemplate, params object[] args);
        ConsoleKeyInfo ReadKey();
    }
}