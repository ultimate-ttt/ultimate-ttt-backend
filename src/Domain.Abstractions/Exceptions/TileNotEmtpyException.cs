using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class TileNotEmptyException : InvalidMoveException
    {
        public TileNotEmptyException() : base(ExceptionMessages.TileNotEmpty)
        {
        }
    }
}
