using FluentAssertions;
using Snapshooter.Xunit;
using UltimateTicTacToe.Abstractions;
using Xunit;

namespace UltimateTicTacToe.Domain.Tests
{
    public class BoardExtensionTests
    {
        [Fact]
        public void GetAllLinesOfBoard_ValidSmallTileInformation_ShouldReturnAllLines()
        {
            // arrange
            var board = new SmallTileInformation[3][];

            for (int x = 0; x < 3; x++)
            {
                board[x] = new SmallTileInformation[3];
                for (int y = 0; y < 3; y++)
                {
                    board[x][y] = new SmallTileInformation
                    {
                        BoardPosition = new Position(0, 0),
                        Position = new Position(x, y),
                        Value = TileValue.Empty,
                    };
                }
            }

            // act
            var result = board.GetAllLinesOfBoard();

            // assert
            result.Should().HaveCount(8);
            Snapshot.Match(result);
        }

        [Fact]
        public void GetAllLinesOfBoard_ValidSmallBoardInformation_ShouldReturnAllLines()
        {
            // arrange
            var board = new SmallBoardInformation[3][];

            for (int x = 0; x < 3; x++)
            {
                board[x] = new SmallBoardInformation[3];
                for (int y = 0; y < 3; y++)
                {
                    board[x][y] = new SmallBoardInformation
                    {
                       Position = new Position(x, y),
                       Value = TileValue.Empty,
                    };
                }
            }

            // act
            var result = board.GetAllLinesOfBoard();

            // assert
            result.Should().HaveCount(8);
            Snapshot.Match(result);
        }
    }
}
