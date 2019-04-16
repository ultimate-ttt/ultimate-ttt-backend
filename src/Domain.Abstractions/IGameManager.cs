using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Domain.Abstractions
{
    public interface IGameManager
    {
        Task<Game> CreateGame(CancellationToken cancellationToken);
        Task<MoveResult> Move(Move m, CancellationToken cancellationToken);
    }

    public class MoveResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public Move Move { get; set; }
    }
}
