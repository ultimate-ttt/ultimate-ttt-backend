using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Domain
{

    public class Game
    {
        private SmallBoardInformation[,] board = new SmallBoardInformation[3, 3];
        private readonly List<Move> _moves;
        private Player _currentPlayer;

        public Game(List<Move> moves)
        {
            _moves = moves;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            board = new SmallBoardInformation[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    board[x, y] = new SmallBoardInformation
                    {
                        Position = new Position(x,y),
                        Value = TileValue.Empty,
                        // TODO: calculate init tiles

                    }
                }
            }
        }
    }
}

public class MoveValidator
{
    private readonly IMoveRepository _moveRepository;
    public async Task<MoveResult> ValidateMove(Move m, CancellationToken ctx)
    {
        var moves = await GetMovesForGameAsync(m.GameId, ctx);

        return null;
    }

    private async Task<List<Move>> GetMovesForGameAsync(string gameId, CancellationToken ctx)
    {
        return await _moveRepository.GetMovesForGame(gameId, ctx);
    }
}
}
