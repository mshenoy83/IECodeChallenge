using System.Collections.Generic;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IPacmanCommandParser : ICommandParser
    {
        List<KeyValuePair<CommandType, string>> GetCommandList();

        void ParseFile(string input);

        PacmanModel ParsePlaceCommand(string input);
        bool IsReportRequested { get; }
    }
}