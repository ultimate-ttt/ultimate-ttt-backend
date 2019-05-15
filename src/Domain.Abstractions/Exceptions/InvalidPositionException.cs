using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class InvalidPositionException : InvalidMoveException
    {
        public InvalidPositionException(Exception inner)
            : base(ExceptionMessages.InvalidPosition, inner)
        {
        }
    }
}
