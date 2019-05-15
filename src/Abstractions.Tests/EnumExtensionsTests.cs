using FluentAssertions;
using Xunit;

namespace UltimateTicTacToe.Abstractions.Tests
{
    public class EnumExtensionsTests
    {
        [Theory]
        [InlineData(Player.Circle, TileValue.Circle)]
        [InlineData(Player.Cross, TileValue.Cross)]
        public void ToTileValue_PlayerInput_ValidOutput(Player input, TileValue expectedOutput)
        {
            // arrange

            // act
            TileValue result = input.ToTileValue();

            // assert
            result.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData(Player.Circle, Winner.Circle)]
        [InlineData(Player.Cross, Winner.Cross)]
        public void ToWinner_PlayerInput_ValidOutput(Player input, Winner expectedOutput)
        {
            // arrange

            // act
            Winner result = input.ToWinner();

            // assert
            result.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData(Player.Circle, Player.Cross)]
        [InlineData(Player.Cross, Player.Circle)]
        public void Invert_PlayerInput_ValidOutput(Player input, Player expectedOutput)
        {
            // arrange

            // act
            Player result = input.Invert();

            // assert
            result.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData(Winner.Circle, TileValue.Circle)]
        [InlineData(Winner.Cross, TileValue.Cross)]
        [InlineData(Winner.None, TileValue.Empty)]
        [InlineData(Winner.Draw, TileValue.Destroyed)]
        public void ToTileValue_WinnerInput_ValidOutput(Winner input, TileValue expectedOutput)
        {
            // arrange

            // act
            TileValue result = input.ToTileValue();

            // assert
            result.Should().Be(expectedOutput);
        }
    }
}
