using System;
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


    }
}
