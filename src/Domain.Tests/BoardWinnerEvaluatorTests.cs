using FluentAssertions;
using UltimateTicTacToe.Abstractions;
using Xunit;

namespace UltimateTicTacToe.Domain.Tests
{
    public class BoardWinnerEvaluatorTests
    {
        [Theory]
        [InlineData(Player.Circle)]
        [InlineData(Player.Cross)]
        private void GetWinner_EmptyBoard_ReturnsWinnerNone(Player lastPlayer)
        {
            // arrange
            var emtyBoard =  new SmallTileInformation[3][];

            for (int x = 0; x < 3; x++)
            {
                emtyBoard[x] = new SmallTileInformation[3];
                for (int y = 0; y < 3; y++)
                {
                    emtyBoard[x][y] = new SmallTileInformation
                    {
                        Value = TileValue.Empty,
                    };
                }
            }

            // act
            var winner = emtyBoard.GetWinner(lastPlayer);

            // assert
            winner.Should().Be(Winner.None);
        }
    }
}
