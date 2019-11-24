using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PathFinder : IPathFinder
    {
        private readonly IPacmanCommandParser _commandParser;

        public PathFinder(IPacmanCommandParser commandParser)
        {
            _commandParser = commandParser;
        }

        public PacmanModel UpdatePacmanPath(List<KeyValuePair<CommandType, string>> commands)
        {
            if (!commands.Any())
                return null;

            var model = new PacmanModel();

            foreach (KeyValuePair<CommandType, string> cmd in commands)
            {
                switch (cmd.Key)
                {
                    case CommandType.PLACE:
                        var parsedCommand = _commandParser.ParsePlaceCommand(cmd.Value);
                        if (parsedCommand == null)
                            return null;
                        model = parsedCommand.Clone() as PacmanModel;
                        break;
                    case CommandType.LEFT:
                        model.DirectionFacing = model.IsInGrid ? GetNewPacmanDirection(TurnTaken.LEFT, model.DirectionFacing) : model.DirectionFacing;
                        break;
                    case CommandType.RIGHT:
                        model.DirectionFacing = model.IsInGrid ? GetNewPacmanDirection(TurnTaken.RIGHT, model.DirectionFacing) : model.DirectionFacing;
                        break;
                    case CommandType.MOVE:
                        model.Position = GetNewPacmanPosition(model);
                        break;
                }
            }

            return model;
        }

        public Point GetNewPacmanPosition(PacmanModel model)
        {
            if (!model.CanMove)
                return model.Position;

            int x = model.Position.X;
            int y = model.Position.Y;
            switch (model.DirectionFacing)
            {
                case Direction.WEST:
                    x--;
                    break;
                case Direction.EAST:
                    x++;
                    break;
                case Direction.NORTH:
                    y++;
                    break;
                case Direction.SOUTH:
                    y--;
                    break;
            }

            return new Point(x, y);
        }

        public Direction GetNewPacmanDirection(TurnTaken turn, Direction currentDirection)
        {
            var rotation = (int)turn;
            var facing = (int)currentDirection;

            facing += rotation;

            if (facing > 3)
                facing = 0;

            if (facing < 0)
                facing = 3;

            return (Direction)facing;

        }
    }
}
