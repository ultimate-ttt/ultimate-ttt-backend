using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Domain
{
    internal class BoardWinnerEvaluator
    {
        private readonly TileInformation[,] _tiles;

        public BoardWinnerEvaluator(TileInformation[,] tiles)
        {
            _tiles = tiles;
        }

        internal Winner GetWinner(Player lastPlayer)
        {
            // TODO: implement

            // has LastPlayer won ==> Wiiner = Playser
            // is Board full ==> Winner ==> Draw
            // Winner ==> none
        }

        private bool IsBoardFull()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (_tiles[x, y].Value == TileValue.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }

    internal class TicTacToeGame
    {
        private SmallBoardInformation[,] _board = new SmallBoardInformation[3, 3];
        private readonly List<Move> _moves;
        private Player _currentPlayer;

        public TicTacToeGame(List<Move> moves)
        {
            _currentPlayer = Player.Cross;
            InitializeBoard();
        }

        public MoveResult Move(Move m)
        {
            SmallBoardInformation board = GetBoard(m.BoardPosition);
            SmallTileInformation tile = GetTile(board, m.TilePosition);

            // TODO: validate if its players move;
            tile.Value = m.Player.ToTileValue();

            return null;
        }

        private SmallBoardInformation GetBoard(Position p)
        {
            try
            {
                return _board[p.X, p.Y];
            }
            catch (IndexOutOfRangeException ex)
            {

                throw new InvalidPositionException(
                    "Invalid Board Position",
                    ex
                );
            }
        }

        private SmallTileInformation GetTile(SmallBoardInformation board, Position p)
        {
            try
            {
                return board.Tiles[p.X, p.Y];
            }
            catch (IndexOutOfRangeException ex)
            {

                throw new InvalidPositionException(
                    "Invalid Tile Position",
                    ex
                );
            }
        }

        #region Initialize
        private void InitializeBoard()
        {
            _board = new SmallBoardInformation[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    _board[x, y] = new SmallBoardInformation
                    {
                        Position = new Position(x, y),
                        Value = TileValue.Empty,
                        Tiles = GenerateTiles(x, y)
                    };
                }
            }
        }

        private SmallTileInformation[,] GenerateTiles(int boardX, int boardY)
        {
            SmallTileInformation[,] tiles = new SmallTileInformation[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {

                    tiles[x, y] = new SmallTileInformation
                    {
                        BoardPosition = new Position(boardX, boardY),
                        Position = new Position(x, y),
                        Value = TileValue.Empty,

                    };
                }
            }

            return tiles;
        }

        private void ApplyMoves(List<Move> moves)
        {
            moves.ForEach(m => Move(m));
        }
        #endregion
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

