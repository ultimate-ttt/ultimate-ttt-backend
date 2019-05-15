using System;

namespace UltimateTicTacToe.Abstractions
{
    public sealed class Position : IEquatable<Position>
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Position other)
        {
            if (other == null)
            {
                return false;
            }

            return X == other.X && Y == other.Y;
        }
    }
}
