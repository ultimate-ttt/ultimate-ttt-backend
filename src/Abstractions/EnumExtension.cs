using System;

namespace UltimateTicTacToe.Abstractions
{
    public static class EnumExtension
    {
        public static TileValue ToTileValue(this Player player)
        {
            if (player == Player.Cross)
            {
                return TileValue.Cross;
            }

            return TileValue.Circle;
        }

        public static TileValue ToTileValue(this Winner winner)
        {
            switch (winner)
            {
                case Winner.Cross:
                    return TileValue.Cross;
                case Winner.Circle:
                    return TileValue.Circle;
                case Winner.None:
                    return TileValue.Empty;
                case Winner.Draw:
                    return TileValue.Destroyed;
                default:
                    throw new ArgumentOutOfRangeException(nameof(winner), winner, null);
            }
        }

        public static Winner ToWinner(this Player player)
        {
            if (player == Player.Cross)
            {
                return Winner.Cross;
            }

            return Winner.Circle;
        }

        public static Player Invert(this Player player)
        {
            if (player == Player.Cross)
            {
                return Player.Circle;
            }

            return Player.Cross;
        }
    }
}
