using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;
using Xunit;

namespace UltimateTicTacToe.Domain.Tests
{
    public class MoveValidatorTests
    {
        [Fact]
        public async Task ValidateMoveAsync_FirstMove_CorrectMoveNumber()
        {
            // arrange
            var moveRepositoryMock = new Mock<IMoveRepository>();
            moveRepositoryMock
                .Setup(m => m.GetMovesForGame(It.IsAny<string>(), CancellationToken.None))
                .Returns(() => Task.FromResult(new List<Move>()))
                .Verifiable();

            var gameManager = new MoveValidator(moveRepositoryMock.Object);

            // act
            MoveResult result = await gameManager.ValidateMoveAsync(
                new Move
                {
                    GameId = "abc",
                    BoardPosition = new Position
                    {
                        X = 0,
                        Y = 0
                    },
                    TilePosition = new Position
                    {
                        X = 0,
                        Y = 0
                    },
                    Player = Player.Cross
                }, CancellationToken.None);

            // assert
            result.Move.MoveNumber.Should().Be(1);
        }

        [Fact]
        public async Task ValidateMoveAsync_ValidMove_CorrectMoveNumber()
        {
            // arrange
            var moveRepositoryMock = new Mock<IMoveRepository>();
            moveRepositoryMock
                .Setup(m => m.GetMovesForGame(It.IsAny<string>(), CancellationToken.None))
                .Returns(() => Task.FromResult(new List<Move>
                {
                    new Move
                    {
                        GameId = "abc",
                        BoardPosition = new Position
                        {
                            X = 0,
                            Y = 0
                        },
                        TilePosition = new Position
                        {
                            X = 0,
                            Y = 0
                        },
                        Player = Player.Cross
                    },
                    new Move
                    {
                        GameId = "abc",
                        BoardPosition = new Position
                        {
                            X = 0,
                            Y = 0
                        },
                        TilePosition = new Position
                        {
                            X = 1,
                            Y = 0
                        },
                        Player = Player.Circle
                    }
                }))
                .Verifiable();

            var gameManager = new MoveValidator(moveRepositoryMock.Object);

            // act
            MoveResult result = await gameManager.ValidateMoveAsync(
                new Move
                {
                    GameId = "abc",
                    BoardPosition = new Position
                    {
                        X = 1,
                        Y = 0
                    },
                    TilePosition = new Position
                    {
                        X = 0,
                        Y = 0
                    },
                    Player = Player.Cross
                }, CancellationToken.None);

            // assert
            result.Move.MoveNumber.Should().Be(3);
        }
    }
}
