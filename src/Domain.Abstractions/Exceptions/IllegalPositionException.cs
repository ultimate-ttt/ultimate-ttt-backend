using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class IllegalPositionException : InvalidMoveException
    {
        public IllegalPositionException()
            : base(ExceptionMessages.IllegalPosition)
        {
        }

        public IllegalPositionException(Exception inner)
            : base(ExceptionMessages.IllegalPosition, inner)
        {
        }
    }
}
