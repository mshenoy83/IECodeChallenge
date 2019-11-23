using System;
using System.Collections.Generic;
using System.Text;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PathFinder : IPathFinder
    {
        public PacmanModel UpdatePacmanPath(List<KeyValuePair<CommandType,string>> commands)
        {
            var model = new PacmanModel();

            foreach (var cmd in commands)
            {

            }
        }
    }
}
