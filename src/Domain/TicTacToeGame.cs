using System;
using System.Collections.Generic;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Domain
{
    internal class TicTacToeGame
    {
        private SmallBoardInformation[,] _board = new SmallBoardInformation[3, 3];
        private readonly List<Move> _moves = new List<Move>();
        private Player _currentPlayer;

        public TicTacToeGame(List<Move> moves)
        {
            _currentPlayer = Player.Cross;
            InitializeBoard();
            ApplyMoves(moves);
        }

        public MoveResult Move(Move m)
        {
            try
            {
                SmallBoardInformation board = GetBoard(m.BoardPosition);
                SmallTileInformation tile = GetTile(board, m.TilePosition);

                // TODO: validate if its players move;
                tile.Value = m.Player.ToTileValue();
                
                Winner winner = new BoardWinnerEvaluator(board.Tiles).GetWinner(m.Player);
            }
            catch (InvalidPositionException e)
            {
                //TODO: maybe attach reason for invalidity
                return new MoveResult
                {
                    IsValid = false,
                    Move = m,
                };
            }

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
                        Position = new Position(x, y), Value = TileValue.Empty, Tiles = GenerateTiles(x, y)
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