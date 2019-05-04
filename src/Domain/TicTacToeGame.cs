using System;
using System.Collections.Generic;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;
using UltimateTicTacToe.Domain.Abstractions.Exceptions;

namespace UltimateTicTacToe.Domain
{
    internal class TicTacToeGame
    {
        private SmallBoardInformation[][] _board;
        private readonly List<Move> _moves;
        private Player _currentPlayer;

        public TicTacToeGame(List<Move> moves)
        {
            InitializeBoard();
            _moves = new List<Move>();
            _currentPlayer = Player.Cross;

            ApplyMoves(moves);
        }

        public MoveResult Move(Move m)
        {
            try
            {
                ThrowIfNotPlayersMove(m.Player);
                SmallBoardInformation board = GetBoard(m.BoardPosition);
                SmallTileInformation tile = GetTile(board, m.TilePosition);

                tile.Value = m.Player.ToTileValue();

                Winner winner = new BoardWinnerEvaluator(board.Tiles).GetWinner(m.Player);
            }
            catch (InvalidMoveException e)
            {
                //TODO: maybe attach reason for invalidity
                return new MoveResult {IsValid = false, Move = m,};
            }

            return null;
        }

        private void ThrowIfNotPlayersMove(Player player)
        {
            if (_currentPlayer.Equals(player))
            {
                throw new InvalidPlayerException();
            }
        }

        private SmallBoardInformation GetBoard(Position p)
        {
            try
            {
                return _board[p.X][p.Y];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidPositionException(ex);
            }
        }

        private SmallTileInformation GetTile(SmallBoardInformation board, Position p)
        {
            try
            {
                return board.Tiles[p.X][p.Y];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidPositionException(ex);
            }
        }

        #region Initialize

        private void InitializeBoard()
        {
            _board = new SmallBoardInformation[3][];
            for (int x = 0; x < 3; x++)
            {
                _board[x] = new SmallBoardInformation[3];
                for (int y = 0; y < 3; y++)
                {
                    _board[x][y] = new SmallBoardInformation
                    {
                        Position = new Position(x, y), Value = TileValue.Empty, Tiles = GenerateTiles(x, y)
                    };
                }
            }
        }

        private SmallTileInformation[][] GenerateTiles(int boardX, int boardY)
        {
            SmallTileInformation[][] tiles = new SmallTileInformation[3][];

            for (int x = 0; x < 3; x++)
            {
                tiles[x] = new SmallTileInformation[3];
                for (int y = 0; y < 3; y++)
                {
                    tiles[x][y] = new SmallTileInformation
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