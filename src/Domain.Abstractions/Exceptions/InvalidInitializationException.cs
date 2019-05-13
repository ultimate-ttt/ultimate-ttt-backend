using System;

namespace UltimateTicTacToe.Domain.Abstractions.Exceptions
{
    public class InvalidInitializationException : Exception
    {
        public InvalidInitializationException(int moveId)
                : base(
                    string.Format(ExceptionMessages.InvalidInitialization, moveId)
                )
        {


        }

        public MoveResult MoveResult { get; set; }
    }
}
