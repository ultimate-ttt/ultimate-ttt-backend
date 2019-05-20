using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Api.Input;
using UltimateTicTacToe.Api.Messages;
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

        public async Task<MoveResult> Move(
            MoveInput input,
            [Service] IGameManager gameManager,
            [Service] IEventSender eventSender,
            CancellationToken cancellationToken
        )
        {
            var result = await gameManager.Move(input.ToMove(), cancellationToken);

            if (result.IsValid)
            {
                await eventSender.SendAsync(new OnMoveMessage(result.Move));
            }

            return result;
        }
    }
}
