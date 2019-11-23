using System.Collections.Generic;

namespace IECodeChallenge.Services
{
    public interface ICommandParser
    {
        List<string> GetCommandList();
        bool IsValidPlaceCommand(string input);
        void ParseCommand(string input);
        void ParseFile(string input);
    }
}