using System;
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
    public class GameManagerTests
    {
        [Fact]
        public void Constructor_GameRepositoryNull_ArgumentNullException()
        {
            // arrange

            // act
            Action a = () =>
            {
                new GameManager(null, Mock.Of<IMoveRepository>(), Mock.Of<IMoveValidator>());
            };

            // assert
            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_MoveRepositoryNull_ArgumentNullException()
        {
            // arrange

            // act
            Action a = () =>
            {
                new GameManager(Mock.Of<IGameRepository>(), null, Mock.Of<IMoveValidator>());
            };

            // assert
            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_MoveValidatorNull_ArgumentNullException()
        {
            // arrange

            // act
            Action a = () =>
            {
                new GameManager(Mock.Of<IGameRepository>(), Mock.Of<IMoveRepository>(), null);
            };

            // assert
            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task CreateGame_ReturnsValidNewGame()
        {
            // arrange
            var gameManager = new GameManager(Mock.Of<IGameRepository>(),
                Mock.Of<IMoveRepository>(),
                Mock.Of<IMoveValidator>());

            // act
            var game = await gameManager.CreateGame(CancellationToken.None);

            // assert
            game.Id.Should().NotBeNullOrWhiteSpace();
            game.Winner.Should().BeNull();
            game.FinishedAt.Should().BeNull();
        }

        [Fact]
        public async Task CreateGame_SavesGameInGameRepository()
        {
            // arrange
            Mock<IGameRepository> gameRepositoryMock = new Mock<IGameRepository>();
            gameRepositoryMock
                .Setup(m => m.Save(It.IsAny<Game>(), CancellationToken.None))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var gameManager = new GameManager(gameRepositoryMock.Object, Mock.Of<IMoveRepository>(),
                Mock.Of<IMoveValidator>());

            // act
            var game = await gameManager.CreateGame(CancellationToken.None);

            // assert
            gameRepositoryMock.Verify(m => m.Save(It.IsAny<Game>(), CancellationToken.None),
                Times.Once);
        }

        [Fact]
        public async Task Move_ValidMove_SavesToMoveRepository()
        {
            // arrange
            var move = new Move
            {
                GameId = "abc",
                BoardPosition = new Position {X = 1, Y = 0},
                TilePosition = new Position {X = 0, Y = 0},
                Player = Player.Cross
            };
            Mock<IGameRepository> gameRepositoryMock = new Mock<IGameRepository>();
            gameRepositoryMock
                .Setup(r => r.GetById("abc", CancellationToken.None))
                .ReturnsAsync(new Game {Id = "abc", Winner = Winner.None});

            Mock<IMoveValidator> moveValidatorMock = new Mock<IMoveValidator>();
            moveValidatorMock
                .Setup(m => m.ValidateMoveAsync(It.IsAny<Move>(), CancellationToken.None))
                .ReturnsAsync(new MoveResult {IsValid = true, Move = move});

            Mock<IMoveRepository> moveRepositoryMock = new Mock<IMoveRepository>();
            moveRepositoryMock
                .Setup(m => m.GetMovesForGame(It.IsAny<string>(), CancellationToken.None))
                .Returns(() => Task.FromResult(new List<Move>()))
                .Verifiable();
            moveRepositoryMock
                .Setup(m => m.Save(It.IsAny<Move>(), CancellationToken.None))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var gameManager = new GameManager(gameRepositoryMock.Object, moveRepositoryMock.Object,
                moveValidatorMock.Object);

            // act
            var result =
                await gameManager.Move(
                    move, CancellationToken.None);

            // assert
            moveRepositoryMock
                .Verify(m => m.Save(It.IsAny<Move>(), CancellationToken.None), Times.Once);
        }


        [Fact]
        public async Task Move_NonExistentGame_ReturnsMoveInvalid()
        {
            // arrange
            var move = new Move
            {
                GameId = "abc",
                BoardPosition = new Position {X = 1, Y = 0},
                TilePosition = new Position {X = 0, Y = 0},
                Player = Player.Cross
            };
            Mock<IGameRepository> gameRepositoryMock = new Mock<IGameRepository>();
            gameRepositoryMock
                .Setup(r => r.GetById("abc", CancellationToken.None))
                .ReturnsAsync((Game)null);


            var gameManager = new GameManager(
                gameRepositoryMock.Object,
                Mock.Of<IMoveRepository>(),
                Mock.Of<IMoveValidator>());

            // act
            var result =
                await gameManager.Move(
                    move, CancellationToken.None);

            // assert
            result.IsValid.Should().BeFalse();
        }
    }
}
