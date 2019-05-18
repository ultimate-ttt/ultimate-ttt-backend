using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Data.Abstractions
{
    public interface IGameRepository
    {
        Task<Game> GetById(string id, CancellationToken cancellationToken);

        Task Save(Game game, CancellationToken cancellationToken);
    }
}
