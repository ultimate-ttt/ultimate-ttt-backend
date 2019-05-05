using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Domain.Abstractions
{
    public interface IMoveValidator
    {
        Task<MoveResult> ValidateMoveAsync(Move m, CancellationToken ctx);
    }
}
