using FluentAssertions;
using Xunit;

namespace UltimateTicTacToe.Abstractions.Tests
{
    public class PositionTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0, true)]
        [InlineData(0, 0, 0, 1, false)]
        [InlineData(0, 0, 1, 0, false)]
        [InlineData(0, 0, 1, 1, false)]
        [InlineData(0, 1, 0, 0, false)]
        [InlineData(1, 0, 0, 0, false)]
        [InlineData(1, 1, 0, 0, false)]
        [InlineData(1, 1, 1, 1, true)]
        public void Equals_VariousInput_CorrectResult(
            int p1X,
            int p1Y,
            int p2X,
            int p2Y,
            bool isEqual)
        {
            // arrange
            var position1 = new Position(p1X, p1Y);
            var position2 = new Position(p2X, p2Y);
            // act
            var result = position1.Equals(position2);

            // assert
            result.Should().Be(isEqual);
        }

        [Fact]
        public void Equals_Null_False()
        {
            // arrange
            var p = new Position(0, 0);

            // act
            var result = p.Equals(null);

            // assert
            result.Should().BeFalse();
        }
    }
}
