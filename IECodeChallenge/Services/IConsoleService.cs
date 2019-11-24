namespace IECodeChallenge.Services
{
    public interface IConsoleService
    {
        string ReadLine();
        void Writeline(string messageTemplate, params object[] args);
    }
}