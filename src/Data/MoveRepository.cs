using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;

namespace UltimateTicTacToe.Data
{
    public class MoveRepository : IMoveRepository
    {
        private readonly List<Move> _moves = new List<Move>();

        public async Task<List<Move>> GetMovesForGame(Guid gameId,
            CancellationToken cancellationToken)
        {
            return _moves.Where(m => m.GameId.Equals(gameId)).ToList();
        }

        public async Task Save(Move move, CancellationToken cancellationToken)
        {
            _moves.Add(move);
        }
    }
}
