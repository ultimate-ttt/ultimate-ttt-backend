using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class InvalidPlayerException : InvalidMoveException
    {
        public InvalidPlayerException() : base(ExceptionMessages.InvalidPlayer)
        {
        }

        public InvalidPlayerException(Exception inner) : base(ExceptionMessages.InvalidPlayer, inner)
        {
        }
    }
}