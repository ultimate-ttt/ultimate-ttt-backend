using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;

namespace UltimateTicTacToe.Api
{
    public class Query
    {
        public async Task<Game> GetGame(
            string id,
            [Service] IGameRepository gameRepository,
            CancellationToken cancellationToken
        )
        {
            return await gameRepository.GetById(id, cancellationToken);
        }
    }
}
