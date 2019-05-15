using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public abstract class InvalidMoveException : Exception
    {
        protected InvalidMoveException(string message)
            : base(message)
        {
        }

        protected InvalidMoveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
