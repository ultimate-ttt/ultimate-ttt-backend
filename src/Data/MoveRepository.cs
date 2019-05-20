using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;

namespace UltimateTicTacToe.Data
{
    public class MoveRepository : IMoveRepository
    {
        private readonly IMongoCollection<Move> _moveCollection;

        public MoveRepository(IMongoCollection<Move> moveCollection)
        {
            _moveCollection = moveCollection;
        }

        public async Task<List<Move>> GetMovesForGame(string gameId,
            CancellationToken cancellationToken)
        {
            return await _moveCollection
                .AsQueryable()
                .Where(m => m.GameId.Equals(gameId))
                .ToListAsync
                    (cancellationToken);
        }

        public async Task Save(Move move, CancellationToken cancellationToken)
        {
            await _moveCollection.InsertOneAsync(move, cancellationToken: cancellationToken);
        }
    }
}
