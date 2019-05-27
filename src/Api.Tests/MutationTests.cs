using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Subscriptions;
using Moq;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Api.Input;
using UltimateTicTacToe.Domain.Abstractions;
using Xunit;

namespace UltimateTicTacToe.Api.Tests
{
    public class MutationTests
    {
        [Fact]
        public async Task Move_ValidMove_SendsEvent()
        {
            // arrange
            var moveInput = new MoveInput
            {
                GameId = "abcdef",
                Player = Player.Cross,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(0, 0)
            };

            var gameManagerMock = new Mock<IGameManager>();
            gameManagerMock
                .Setup(m => m.Move(It.IsAny<Move>(), CancellationToken.None))
                .ReturnsAsync(new MoveResult
                {
                    Move = moveInput.ToMove(),
                    InvalidReason = null,
                    IsValid = true,
                    MoveFinishedGame = false,
                    MoveFinishedBoard = false,
                });

            var eventSenderMock = new Mock<IEventSender>();
            eventSenderMock
                .Setup(m => m.SendAsync(It.IsAny<IEventMessage>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var mutation = new Mutation();


            //act
            var result = await mutation.Move(
                moveInput,
                gameManagerMock.Object,
                eventSenderMock.Object,
                CancellationToken.None);

            //assert
            eventSenderMock.Verify(m => m.SendAsync(It.IsAny<IEventMessage>()), Times.Once);
        }

        [Fact]
        public async Task Move_InvalidMove_DoesNotSendEvent()
        {
            // arrange
            var moveInput = new MoveInput
            {
                GameId = "abcdef",
                Player = Player.Cross,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(0, 0)
            };

            var gameManagerMock = new Mock<IGameManager>();
            gameManagerMock
                .Setup(m => m.Move(It.IsAny<Move>(), CancellationToken.None))
                .ReturnsAsync(new MoveResult
                {
                    Move = moveInput.ToMove(),
                    InvalidReason = null,
                    IsValid = false,
                    MoveFinishedGame = false,
                    MoveFinishedBoard = false,
                });

            var eventSenderMock = new Mock<IEventSender>();
            eventSenderMock
                .Setup(m => m.SendAsync(It.IsAny<IEventMessage>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var mutation = new Mutation();


            //act
            var result = await mutation.Move(
                moveInput,
                gameManagerMock.Object,
                eventSenderMock.Object,
                CancellationToken.None);

            //assert
            eventSenderMock.Verify(m => m.SendAsync(It.IsAny<IEventMessage>()), Times.Never);
        }

        [Fact]
        public async Task Move_ValidInput_CallsGameManager()
        {
            // arrange
            var moveInput = new MoveInput
            {
                GameId = "abcdef",
                Player = Player.Cross,
                BoardPosition = new Position(0, 0),
                TilePosition = new Position(0, 0)
            };

            var gameManagerMock = new Mock<IGameManager>();
            gameManagerMock
                .Setup(m => m.Move(It.IsAny<Move>(), CancellationToken.None))
                .ReturnsAsync(new MoveResult
                {
                    Move = moveInput.ToMove(),
                    InvalidReason = null,
                    IsValid = false,
                    MoveFinishedGame = false,
                    MoveFinishedBoard = false,
                });

            var eventSenderMock = new Mock<IEventSender>();
            eventSenderMock
                .Setup(m => m.SendAsync(It.IsAny<IEventMessage>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var mutation = new Mutation();


            //act
            var result = await mutation.Move(
                moveInput,
                gameManagerMock.Object,
                eventSenderMock.Object,
                CancellationToken.None);

            //assert
            gameManagerMock.Verify(
                m => m.Move(It.IsAny<Move>(), CancellationToken.None),
                Times.Once);
        }
    }
}
