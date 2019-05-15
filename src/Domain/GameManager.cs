using System;
using System.Collections.Generic;
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
        private readonly IMoveValidator _moveValidator;

        public GameManager(
            IGameRepository gameRepository,
            IMoveRepository moveRepository,
            IMoveValidator moveValidator)
        {
            _gameRepository = gameRepository
                              ?? throw new ArgumentNullException(nameof(gameRepository));
            _moveRepository = moveRepository
                              ?? throw new ArgumentNullException(nameof(moveRepository));
            _moveValidator = moveValidator
                             ?? throw new ArgumentNullException(nameof(moveValidator));
        }

        public async Task<Game> CreateGame(CancellationToken cancellationToken)
        {
            var g = new Game
            {
                Id = ReadableIdGenerator.NewId(),
                Winner = null,
                FinishedAt = null,
            };

            await _gameRepository.Save(g, cancellationToken);

            return g;
        }

        public async Task<MoveResult> Move(Move m, CancellationToken cancellationToken)
        {
            if (!await IsGameExistentAsync(m.GameId, cancellationToken))
            {
                return new MoveResult
                {
                    Move = m,
                    IsValid = false
                };
            }

            MoveResult result = await _moveValidator.ValidateMoveAsync(m, cancellationToken);

            if (result.IsValid)
            {
                await _moveRepository.Save(result.Move, cancellationToken);
            }

            return result;
        }

        private async Task<bool> IsGameExistentAsync(string id, CancellationToken ctx)
        {
            Game game = await _gameRepository.GetById(id, ctx);
            return game != null;
        }
    }
}
