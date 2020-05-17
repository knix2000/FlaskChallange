using System;

namespace FlaskChallange
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool SamePositionAs(Coordinate other)
        {
            if (X == other.X && Y == other.Y)
            {
                return true;
            }
            return false;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Coordinate other = (Coordinate)obj;
                return (X == other.X && Y == other.Y);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Coordinate first, Coordinate second)
        {
            return (first.X == second.X && first.Y == second.Y);
        }
        public static bool operator !=(Coordinate first, Coordinate second)
        {
            return !(first.X == second.X && first.Y == second.Y);
        }
    }
}
