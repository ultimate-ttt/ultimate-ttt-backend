using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayer = "It's not the given Players turn";
        public const string InvalidPosition = "The given position is not on the Board";
    }

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

    public class InvalidPlayerException : InvalidMoveException
    {
        public InvalidPlayerException() : base(ExceptionMessages.InvalidPlayer)
        {
        }

        public InvalidPlayerException(Exception inner) : base(ExceptionMessages.InvalidPlayer, inner)
        {
        }
    }

    public class InvalidPositionException : InvalidMoveException
    {
        public InvalidPositionException() : base(ExceptionMessages.InvalidPosition)
        {
        }

        public InvalidPositionException(Exception inner) : base(ExceptionMessages.InvalidPosition, inner)
        {
        }
    }
}
