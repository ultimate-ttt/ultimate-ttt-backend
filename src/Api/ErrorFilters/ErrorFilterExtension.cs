using HotChocolate.Execution;

namespace UltimateTicTacToe.Api.ErrorFilters
{
    public static class ErrorFilterExtension
    {
        public static IQueryExecutionBuilder AddCustomErrorFilters(
            this IQueryExecutionBuilder builder)
        {
            builder.AddErrorFilter<ArgumentErrorFilter>();
            return builder;
        }
    }
}
