using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Domain
{
    public class MoveValidator : IMoveValidator
    {
        private readonly IMoveRepository _moveRepository;

        public MoveValidator(IMoveRepository moveRepository)
        {
            _moveRepository = moveRepository;
        }

        public async Task<MoveResult> ValidateMoveAsync(Move m, CancellationToken ctx)
        {
            var moves = await GetMovesForGameAsync(m.GameId, ctx);
            m.MoveNumber = moves.Count + 1;

            var game = new TicTacToeGame(moves);
            MoveResult result = game.Move(m);

            return result;
        }

        private async Task<List<Move>> GetMovesForGameAsync(string gameId, CancellationToken ctx)
        {
            return await _moveRepository.GetMovesForGame(gameId, ctx);
        }
    }
}
