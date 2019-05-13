using System;
using System.Collections.Generic;
using FluentAssertions;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Domain.Abstractions.Exceptions;
using Xunit;

namespace UltimateTicTacToe.Domain.Tests
{
    public class TicTacToeGameTests
    {
        #region Constructor

        [Fact]
        public void Constructor_MovesNull_ThrowsArgumentException()
        {
            // arrange

            //act
            Action a = () =>
            {
                new TicTacToeGame(null);
            };
            //assert
            a.Should().Throw<ArgumentNullException>();
        }

        #endregion

        #region Correct Player at start

        [Fact]
        public void Move_FistMoveByCircle_InvalidMove()
        {
            // arrange
            var game = new TicTacToeGame(new List<Move>());

            //act
            var result = game.Move(new Move
            {
                Player = Player.Circle,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(0, 0),
                MoveNumber = 1
            });

            //assert
            result.IsValid.Should().BeFalse();
            result.InvalidReason.Should().Be(ExceptionMessages.InvalidPlayer);
        }

        [Fact]
        public void Move_FistMoveByCross_ValidMove()
        {
            // arrange
            var game = new TicTacToeGame(new List<Move>());

            //act
            var result = game.Move(new Move
            {
                Player = Player.Cross,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(0, 0),
                MoveNumber = 1
            });

            //assert
            result.IsValid.Should().BeTrue();
            result.InvalidReason.Should().BeNull();
        }

        #endregion

        #region Invalid Positions

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        [InlineData(3, 3)]
        [InlineData(3, 0)]
        [InlineData(0, 3)]
        public void Move_FirstInvalidBoardPositions_InvalidMove(int x, int y)
        {
            // arrange
            var game = new TicTacToeGame(new List<Move>());

            //act
            var result = game.Move(new Move
            {
                Player = Player.Cross,
                BoardPosition = new Position(x, y),
                TilePosition = new Position(0, 0),
                MoveNumber = 1
            });

            //assert
            result.IsValid.Should().BeFalse();
            result.InvalidReason.Should().Be(ExceptionMessages.InvalidPosition);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        public void Move_FirstValidBoardPositions_ValidMove(int x, int y)
        {
            // arrange
            var game = new TicTacToeGame(new List<Move>());

            //act
            var result = game.Move(new Move
            {
                Player = Player.Cross,
                BoardPosition = new Position(x, y),
                TilePosition = new Position(0, 0),
                MoveNumber = 1
            });

            //assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        [InlineData(3, 3)]
        [InlineData(3, 0)]
        [InlineData(0, 3)]
        public void Move_FirstInvalidTilePositions_InvalidMove(int x, int y)
        {
            // arrange
            var game = new TicTacToeGame(new List<Move>());

            //act
            var result = game.Move(new Move
            {
                Player = Player.Cross,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(x, y),
                MoveNumber = 1
            });

            //assert
            result.IsValid.Should().BeFalse();
            result.InvalidReason.Should().Be(ExceptionMessages.InvalidPosition);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        public void Move_FirstValidTilePositions_ValidMove(int x, int y)
        {
            // arrange
            var game = new TicTacToeGame(new List<Move>());

            //act
            var result = game.Move(new Move
            {
                Player = Player.Cross,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(x, y),
                MoveNumber = 1
            });

            //assert
            result.IsValid.Should().BeTrue();
        }

        #endregion

        #region Game Finished

        [Fact]
        private void Move_GameFinished_NoMovePossible()
        {
            // arrange

            #region Moves of a finished Game

            List<Move> movesForFinishedGame = new List<Move>
            {
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(0, 0),
                    TilePosition = new Position(0, 0),
                    MoveNumber = 1
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(0, 0),
                    TilePosition = new Position(2, 0),
                    MoveNumber = 2
                },
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(2, 0),
                    TilePosition = new Position(0, 2),
                    MoveNumber = 3
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(0, 2),
                    TilePosition = new Position(2, 0),
                    MoveNumber = 4
                },
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(2, 0),
                    TilePosition = new Position(0, 1),
                    MoveNumber = 5
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(0, 1),
                    TilePosition = new Position(2, 0),
                    MoveNumber = 6
                },
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(2, 0),
                    TilePosition = new Position(0, 0),
                    MoveNumber = 7
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(0, 0),
                    TilePosition = new Position(1, 0),
                    MoveNumber = 8
                },
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(1, 0),
                    TilePosition = new Position(2, 2),
                    MoveNumber = 9
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(2, 2),
                    TilePosition = new Position(0, 0),
                    MoveNumber = 10
                }, new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(0, 0),
                    TilePosition = new Position(0, 1),
                    MoveNumber = 11
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(0, 1),
                    TilePosition = new Position(0, 0),
                    MoveNumber = 12
                },
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(0, 0),
                    TilePosition = new Position(0, 2),
                    MoveNumber = 13
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(0, 2),
                    TilePosition = new Position(1, 0),
                    MoveNumber = 14
                }, new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(1, 0),
                    TilePosition = new Position(2, 0),
                    MoveNumber = 15
                },
                new Move
                {
                    Player = Player.Circle,
                    BoardPosition = new Position(1, 1),
                    TilePosition = new Position(1, 0),
                    MoveNumber = 16
                },
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(1, 0),
                    TilePosition = new Position(2, 1),
                    MoveNumber = 16
                }
            };

            #endregion

            var game = new TicTacToeGame(movesForFinishedGame);

            //act
            var result = game.Move(new Move
            {
                Player = Player.Circle,
                BoardPosition = new Position(2, 1),
                TilePosition = new Position(2, 1),
                MoveNumber = 17
            });

            //assert
            result.IsValid.Should().BeFalse();
            result.InvalidReason.Should().Be(ExceptionMessages.GameFinished);
        }

        #endregion


        #region PlayEntireGame

        [Fact]
        public void Move_ValidFirstMove_CircleCanMakeSecondMove()
        {
            // arrange
            var game = new TicTacToeGame(new[]{
                new Move
                {
                    Player = Player.Cross,
                    BoardPosition = new Position(0, 0),
                    TilePosition = new Position(0, 0),
                    MoveNumber = 1
                }
            });

            // act
            var result = game.Move(new Move
            {
                Player = Player.Circle,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(2, 0),
                MoveNumber = 2
            });

            // assert
            result.IsValid.Should().BeTrue();
        }

        #endregion
    }
}
