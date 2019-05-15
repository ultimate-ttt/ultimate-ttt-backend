using System;
using System.Collections.Generic;
using System.Linq;
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
        private Winner _winner;

        public TicTacToeGame(IEnumerable<Move> moves)
        {
            if (moves == null)
            {
                throw new ArgumentNullException(nameof(moves));
            }

            InitializeBoard();
            _moves = new List<Move>();
            _currentPlayer = Player.Cross;
            _winner = Winner.None;

            ApplyMoves(moves);
        }

        public MoveResult Move(Move m)
        {
            try
            {
                ValidateNoWinner();
                ValidateIsPlayersMove(m.Player);
                ValidateValidBoardToPlay(m.BoardPosition);

                SmallBoardInformation board = GetBoard(m.BoardPosition);
                SmallTileInformation tile = GetTile(board, m.TilePosition);

                ValidateTileEmpty(tile);

                tile.Value = m.Player.ToTileValue();

                Winner winner = board.Tiles.GetWinner(m.Player);
                if (winner != Winner.None)
                {
                    board.Value = winner.ToTileValue();
                    _winner = _board.GetWinner(m.Player);
                }

                // if there is no exception until here the move was valid
                _moves.Add(m);
                ChangeCurrentPlayer();

                return new MoveResult
                {
                    IsValid = true,
                    Move = m,
                    MoveFinishedBoard = winner != Winner.None,
                    MoveFinishedGame = _winner != Winner.None,
                };
            }
            catch (InvalidMoveException e)
            {
                return new MoveResult
                {
                    IsValid = false,
                    Move = m,
                    MoveFinishedBoard = false,
                    MoveFinishedGame = false,
                    InvalidReason = e.Message,
                };
            }
        }

        private void ValidateNoWinner()
        {
            if (_winner != Winner.None)
            {
                throw new GameAlreadyFinishedException();
            }
        }

        private void ValidateTileEmpty(SmallTileInformation tile)
        {
            if (tile.Value != TileValue.Empty)
            {
                throw new TileNotEmptyException();
            }
        }

        private void ValidateValidBoardToPlay(Position positionToValidate)
        {
            if (!_moves.Any())
            {
                //no moves ==> board is empty ==> all moves valid
                return;
            }

            Move lastMove = _moves.Last();
            Position lastMoveTilePosition = lastMove.TilePosition;

            SmallBoardInformation nextBoardFromLastMove =
                _board[lastMoveTilePosition.X][lastMoveTilePosition.Y];

            if (nextBoardFromLastMove.Value == TileValue.Empty)
            {
                // the active board is empty ==> can play here
                if (lastMoveTilePosition.Equals(positionToValidate))
                {
                    // the Position is on this board ==> valid
                    return;
                }

                throw new IllegalPositionException();
            }

            // SmallBoard is full ==> all active | Check if the position is not finished yet
            if (_board[positionToValidate.X][positionToValidate.Y].Value == TileValue.Empty)
            {
                return;
            }

            throw new IllegalPositionException();
        }

        private void ChangeCurrentPlayer()
        {
            _currentPlayer = _currentPlayer.Invert();
        }

        private void ValidateIsPlayersMove(Player player)
        {
            if (_currentPlayer != player)
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
                        Value = TileValue.Empty,
                        Tiles = GenerateTiles(x, y)
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
                        Value = TileValue.Empty,
                    };
                }
            }

            return tiles;
        }

        private void ApplyMoves(IEnumerable<Move> moves)
        {

            foreach (Move m in moves)
            {
                var result = Move(m);

                if (!result.IsValid)
                {
                    throw new InvalidInitializationException(m.MoveNumber)
                    {
                        MoveResult = result
                    };
                }
            }
        }

        #endregion
    }
}
