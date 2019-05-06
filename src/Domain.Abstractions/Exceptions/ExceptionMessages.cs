namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayer = "It's not the given Players turn";
        public const string InvalidPosition = "The given position is not on the Board";
        public const string IllegalPosition = "Not allowed to move here";
        public const string TileNotEmpty = "Can't play here. Tile isn't empty";
        public const string GameFinished = "Can't do any further moves. Game already finished";
    }
}
