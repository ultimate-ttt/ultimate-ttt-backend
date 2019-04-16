using FluentAssertions;
using UltimateTicTacToe.Domain;
using Xunit;

namespace Domain.Tests
{
    public class ReadableIdGeneratorTests
    {
        [Fact]
        public void NewId_ReturnsId()
        {
            // arrange

            //act
            var id = ReadableIdGenerator.NewId();

            //assert
            id.Should().NotBeNullOrWhiteSpace();
        }
    }
}
