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

        //TODO: test if it reacts correctly to invalid positions (not on the board)

        #endregion

        #region Game Finished

        //TODO: validate if it reacts correctly if there is already a winner

        #endregion


        #region PlayEntireGame

        //TODO: Todo play one entire game in a Test

        #endregion
    }
}
