using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public abstract class InvalidMoveException : Exception
    {
        internal InvalidMoveException(string message)
            : base(message)
        {
        }

        internal InvalidMoveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}