using System.Collections.Generic;
using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IPathFinder
    {
        PacmanModel UpdatePacmanPath(List<KeyValuePair<CommandType,string>> commands);
    }
}