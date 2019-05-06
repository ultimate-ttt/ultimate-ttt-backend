namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class IllegalPositionException : InvalidMoveException
    {
        public IllegalPositionException()
            : base(ExceptionMessages.IllegalPosition)
        {
        }
    }
}
