using System;
using System.Drawing;

namespace IECodeChallenge.Models
{
    public class PacmanModel : ICloneable
    {
        public Point Position { get; set; }
        public Direction DirectionFacing { get; set; }

        public bool CanMove
        {
            get
            {
                if (Position.IsEmpty)
                    return false;

                if (1 <= Position.X && Position.X <= 4 && 1 <= Position.Y && Position.Y <= 4)
                    return true;

                switch (DirectionFacing)
                {
                    case Direction.EAST:
                        if (Position.X < 5 && Position.X >= 0)
                            return true;
                        break;
                    case Direction.NORTH:
                        if (Position.Y < 5 && Position.Y >= 0)
                            return true;
                        break;
                    case Direction.SOUTH:
                        if (Position.Y > 0 && Position.Y <= 5)
                            return true;
                        break;
                    case Direction.WEST:
                        if (Position.X > 0 && Position.X <= 5)
                            return true;
                        break;
                }

                return false;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
