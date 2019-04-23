using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;
using UltimateTicTacToe.Domain;
using Xunit;

namespace Domain.Tests
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
                new GameManager(null, Mock.Of<IMoveRepository>());
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
                new GameManager(Mock.Of<IGameRepository>(), null);
            };

            // assert
            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task CreateGame_ReturnsValidNewGame()
        {
            // arrange
            var gameManager = new GameManager(Mock.Of<IGameRepository>(), Mock.Of<IMoveRepository>());

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

            var gameManager = new GameManager(gameRepositoryMock.Object, Mock.Of<IMoveRepository>());

            // act
            var game = await gameManager.CreateGame(CancellationToken.None);

            // assert
            gameRepositoryMock.Verify(m => m.Save(It.IsAny<Game>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Move_FirstMove_CorrectMoveNumber()
        {
            // arrange
            Mock<IMoveRepository> moveRepositoryMock = new Mock<IMoveRepository>();
            moveRepositoryMock
            .Setup(m => m.GetMovesForGame(It.IsAny<string>(), CancellationToken.None))
            .Returns(() => Task.FromResult(new List<Move>()))
            .Verifiable();

            var gameManager = new GameManager(Mock.Of<IGameRepository>(), moveRepositoryMock.Object);

            // act
            var result = await gameManager.Move(new Move
            {
                GameId = "abc",
                BoardPosition = new Position { X = 0, Y = 0 },
                TilePosition = new Position { X = 0, Y = 0 },
                Player = Player.Cross
            }, CancellationToken.None);

            // assert
            result.Move.MoveNumber.Should().Be(1);
        }


    }
}
