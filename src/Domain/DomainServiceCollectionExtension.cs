using Microsoft.Extensions.DependencyInjection;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Domain
{
    public static class DomainServiceCollectionExtension
    {
        public static void AddDomainServices(this IServiceCollection collection)
        {
            collection.AddTransient<IGameManager, GameManager>();
            collection.AddTransient<IMoveValidator, MoveValidator>();
        }
    }
}
