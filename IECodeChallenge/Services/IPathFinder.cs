using System.Collections.Generic;
using System.Drawing;
using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IPathFinder
    {
        PacmanModel UpdatePacmanPath(List<KeyValuePair<CommandType,string>> commands);

        Point MovePacman(PacmanModel model);

        Direction GetNewPacmanDirection(TurnTaken turn, Direction currentDirection, bool isInGrid);
    }
}