using System.Drawing;

namespace IECodeChallenge.Models
{
    public class PacmanModel
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
                    case Direction.East:
                        if (Position.X < 5)
                            return true;
                        break;
                    case Direction.North:
                        if (Position.Y < 5)
                            return true;
                        break;
                    case Direction.South:
                        if (Position.Y > 0)
                            return true;
                        break;
                    case Direction.West:
                        if (Position.X > 0)
                            return true;
                        break;
                }

                return false;
            }
        }
    }
}
