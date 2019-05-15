namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class InvalidPlayerException : InvalidMoveException
    {
        public InvalidPlayerException()
            : base(ExceptionMessages.InvalidPlayer)
        {
        }
    }
}
