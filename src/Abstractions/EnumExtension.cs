namespace UltimateTicTacToe.Abstractions
{
    public static class EnumExtension
    {
        public static TileValue ToTileValue(this Player player)
        {
            if (player == Player.Cross) return TileValue.Cross;

            return TileValue.Circle;
        }

        public static Winner ToWinner(this Player player)
        {
            if (player == Player.Cross) return Winner.Cross;

            return Winner.Circle;
        }

        public static Player Invert(this Player player)
        {
            if (player == Player.Cross) return Player.Circle;

            return Player.Cross;
        }
    }
}
