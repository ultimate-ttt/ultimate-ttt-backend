using System;
using HotChocolate;

namespace UltimateTicTacToe.Api.ErrorFilters
{
    public class ArgumentErrorFilter
        : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is ArgumentException ex) return error.WithMessage(ex.Message);

            return error;
        }
    }
}
