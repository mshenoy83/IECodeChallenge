using System.Collections.Generic;
using System.Drawing;

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
            var model = new PacmanModel();

            foreach (var cmd in commands)
            {
                switch (cmd.Key)
                {
                    case CommandType.PLACE:
                        var placemodel = _commandParser.ParsePlaceCommand(cmd.Value);
                        model.DirectionFacing = placemodel.DirectionFacing;
                        model.Position = new Point(placemodel.XPosition, placemodel.YPosition);
                        break;
                    case CommandType.LEFT:
                        model.DirectionFacing = GetNewPacmanDirection(TurnTaken.LEFT, model.DirectionFacing);
                        break;
                    case CommandType.RIGHT:
                        model.DirectionFacing = GetNewPacmanDirection(TurnTaken.RIGHT, model.DirectionFacing);
                        break;
                    case CommandType.MOVE:
                        model.Position = GetNewPacmanPosition(model);
                        break;
                    default:
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
                case Direction.West:
                    x--;
                    break;
                case Direction.East:
                    x++;
                    break;
                case Direction.North:
                    y++;
                    break;
                case Direction.South:
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

            if (facing > 4)
                facing = 0;

            if (facing < 0)
                facing = 4;

            return (Direction)facing;

        }
    }
}
