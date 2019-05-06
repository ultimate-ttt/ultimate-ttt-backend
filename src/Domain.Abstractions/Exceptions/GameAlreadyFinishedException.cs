namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class GameAlreadyFinishedException : InvalidMoveException
    {
        public GameAlreadyFinishedException()
            : base(ExceptionMessages.GameFinished)
        {
        }
    }
}