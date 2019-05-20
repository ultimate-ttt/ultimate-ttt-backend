using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;

namespace UltimateTicTacToe.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly IMongoCollection<Game> _gameCollection;

        public GameRepository(IMongoCollection<Game> gameCollection)
        {
            _gameCollection = gameCollection;
        }

        public async Task<Game> GetById(string id, CancellationToken cancellationToken)
        {
            return await _gameCollection
                .AsQueryable()
                .Where(g => g.Id.Equals(id))
                .FirstOrDefaultAsync(cancellationToken);
            ;
        }

        public async Task Save(Game game, CancellationToken cancellationToken)
        {
            await _gameCollection
                .InsertOneAsync(
                    game,
                    null,
                    cancellationToken);
        }
    }
}
