using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class InvalidPositionException : InvalidMoveException
    {
        public InvalidPositionException() : base(ExceptionMessages.InvalidPosition)
        {
        }

        public InvalidPositionException(Exception inner) : base(ExceptionMessages.InvalidPosition, inner)
        {
        }
    }

    public class IllegalPositionException : InvalidMoveException
    {
        public IllegalPositionException() : base(ExceptionMessages.IllegalPosition)
        {
        }

        public IllegalPositionException(Exception inner) : base(ExceptionMessages.IllegalPosition, inner)
        {
        }
    }
}
