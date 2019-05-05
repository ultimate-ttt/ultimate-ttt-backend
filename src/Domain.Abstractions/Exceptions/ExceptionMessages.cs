namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayer = "It's not the given Players turn";
        public const string InvalidPosition = "The given position is not on the Board";
        public const string IllegalPosition = "Not allowed to move here";
    }
}
