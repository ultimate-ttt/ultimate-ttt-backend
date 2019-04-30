using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Domain
{
    public class MoveValidator
    {

        public async Task<MoveResult> ValidateMove(Move m, CancellationToken ctx)
        {
            return null;
        }
    }
}
