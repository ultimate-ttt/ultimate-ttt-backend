using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Data.Abstractions
{
    public interface IMoveRepository
    {
        Task<List<Move>> GetMovesForGame(Guid gameId, CancellationToken cancellationToken);
        Task Save(Move move, CancellationToken cancellationToken);
    }
}