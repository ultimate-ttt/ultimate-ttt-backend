using FluentAssertions;
using Xunit;

namespace UltimateTicTacToe.Domain.Tests
{
    public class ReadableIdGeneratorTests
    {
        [Fact]
        public void NewId_ReturnsId()
        {
            // arrange

            // act
            var id = ReadableIdGenerator.NewId();

            // assert
            id.Should().NotBeNullOrWhiteSpace();
        }
    }
}
