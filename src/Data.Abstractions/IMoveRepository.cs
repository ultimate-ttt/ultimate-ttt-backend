using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Data.Abstractions
{
    public interface IMoveRepository
    {
        Task<List<Move>> GetMovesForGame(string gameId, CancellationToken cancellationToken);
        Task Save(Move move, CancellationToken cancellationToken);
    }
}
