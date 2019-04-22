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

        public GameManager(IGameRepository gameRepository, IMoveRepository moveRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _moveRepository = moveRepository ?? throw new ArgumentNullException(nameof(moveRepository));
        }

        public async Task<Game> CreateGame(CancellationToken cancellationToken)
        {
            Game g = new Game {Id = ReadableIdGenerator.NewId(), Winner = null, FinishedAt = null,};

            await _gameRepository.Save(g, cancellationToken);

            return g;
        }

        public async Task<MoveResult> Move(Move m, CancellationToken cancellationToken)
        {
            m.MoveNumber = await GetNextMoveNumber(m.GameId, cancellationToken);

            bool isValidMove = await IsValidMove(m, cancellationToken);
            if (isValidMove)
            {
                await _moveRepository.Save(m, cancellationToken);
            }

            return new MoveResult
            {
                IsValid = isValidMove,
                Message = "", // TODO: make some nice messages here
                Move = m
            };
        }

        private async Task<int> GetNextMoveNumber(string gameId, CancellationToken
            cancellationToken)
        {
            List<Move> moves = await _moveRepository.GetMovesForGame(gameId, cancellationToken);

            return moves.Count + 1;
        }

        private async Task<bool> IsValidMove(Move m, CancellationToken cancellationToken)
        {
            //TODO: implement
            return true;
        }
    }
}
