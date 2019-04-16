using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Domain
{
    public class GameManager : IGameManager
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMoveRepository _moveRepository;

        public GameManager(IGameRepository gameRepository, IMoveRepository moveRepository)
        {
            _gameRepository = gameRepository;
            _moveRepository = moveRepository;
        }

        public async Task<Game> CreateGame(CancellationToken cancellationToken)
        {
            Game g = new Game {Id = Guid.NewGuid(), Winner = null, FinishedAt = null,};

            await _gameRepository.Save(g, cancellationToken);

            return g;
        }

        public async Task<bool> Move(Move m, CancellationToken cancellationToken)
        {
            m.MoveNumber = await GetNextMoveNumber(m.GameId, cancellationToken);

            bool isValidMove = await IsValidMove(m, cancellationToken);
            if (isValidMove)
            {
                await _moveRepository.Save(m, cancellationToken);
            }

            return isValidMove;
        }

        private async Task<int> GetNextMoveNumber(Guid gameId, CancellationToken cancellationToken)
        {
            var moves = await _moveRepository.GetMovesForGame(gameId, cancellationToken);
            return moves.Max(m => m.MoveNumber) + 1;
        }

        private async Task<bool> IsValidMove(Move m, CancellationToken cancellationToken)
        {
            //TODO: implement
            return true;
        }
    }
}
