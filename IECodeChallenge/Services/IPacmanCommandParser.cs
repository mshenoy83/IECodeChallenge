using System.Collections.Generic;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IPacmanCommandParser
    {
        List<KeyValuePair<CommandType,string>> GetCommandList(); 
        void ParseCommand(string input);
        void ParseFile(string input);

        PlacementModel ParsePlaceCommand(string input);
        bool IsReportCommand { get; }
    }
}