using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Api
{
    public class Mutation
    {
        public async Task<Game> CreateGame(
            [Service] IGameManager gameManager,
            CancellationToken cancellationToken
        )
        {
            return await gameManager.CreateGame(cancellationToken);
        }

        public async Task<bool> Move(
            MoveInput input,
            [Service] IGameManager gameManager,
            CancellationToken cancellationToken
        )
        {
            return await gameManager.Move(input.ToMove(), cancellationToken);
        }
    }
}
