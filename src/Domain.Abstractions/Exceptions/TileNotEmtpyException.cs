using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class TileNotEmtpyException : InvalidMoveException
    {
        public TileNotEmtpyException() : base(ExceptionMessages.TileNotEmpty)
        {
        }

        public TileNotEmtpyException(Exception inner) : base(ExceptionMessages.TileNotEmpty, inner)
        {
        }
    }
}
