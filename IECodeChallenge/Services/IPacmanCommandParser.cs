using System.Collections.Generic;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IPacmanCommandParser
    {
        List<KeyValuePair<CommandType,string>> GetCommandList();
        bool IsValidPlaceCommand(string input);
        void ParseCommand(string input);
        void ParseFile(string input);

        bool IsReportCommand { get; }
    }
}