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
        public void GetWinner_EmptyBoard_ReturnsWinnerNone(Player lastPlayer)
        {
            // arrange
            var emptyBoard =  GetEmptyBoard();

            // act
            var winner = emptyBoard.GetWinner(lastPlayer);

            // assert
            winner.Should().Be(Winner.None);
        }

        [Theory]
        [InlineData(0, Player.Cross)]
        [InlineData(1, Player.Cross)]
        [InlineData(2, Player.Cross)]
        [InlineData(0, Player.Circle)]
        [InlineData(1, Player.Circle)]
        [InlineData(2, Player.Circle)]
        public void GetWinner_LinesHorizontalWinner_ReturnsCorrectWinner(int x, Player p)
        {
            // arrange
            var board = GetEmptyBoard();
            for (int y = 0; y < 3; y++)
            {
                board[x][y].Value = p.ToTileValue();
            }

            //act
            var winner = board.GetWinner(p);

            //assert
            winner.Should().Be(p.ToWinner());
        }

        [Theory]
        [InlineData(0, Player.Cross)]
        [InlineData(1, Player.Cross)]
        [InlineData(2, Player.Cross)]
        [InlineData(0, Player.Circle)]
        [InlineData(1, Player.Circle)]
        [InlineData(2, Player.Circle)]
        public void GetWinner_LinesVerticalWinner_ReturnsCorrectWinner(int y, Player p)
        {
            // arrange
            var board = GetEmptyBoard();
            for (int x = 0; x < 3; x++)
            {
                board[x][y].Value = p.ToTileValue();
            }

            //act
            var winner = board.GetWinner(p);

            //assert
            winner.Should().Be(p.ToWinner());
        }

        [Theory]
        [InlineData(Player.Circle)]
        [InlineData(Player.Cross)]
        public void GetWinner_DiagonalTopLeftToBottomRightWinner_ReturnsCorrectWinner(Player p)
        {
            // arrange
            var board = GetEmptyBoard();
            board[0][0].Value = p.ToTileValue();
            board[1][1].Value = p.ToTileValue();
            board[2][2].Value = p.ToTileValue();

            //act
            var winner = board.GetWinner(p);

            //assert
            winner.Should().Be(p.ToWinner());
        }

        [Theory]
        [InlineData(Player.Circle)]
        [InlineData(Player.Cross)]
        public void GetWinner_DiagonalBottomLeftToTopRightWinner_ReturnsCorrectWinner(Player p)
        {
            // arrange
            var board = GetEmptyBoard();
            board[2][0].Value = p.ToTileValue();
            board[1][1].Value = p.ToTileValue();
            board[0][2].Value = p.ToTileValue();

            //act
            var winner = board.GetWinner(p);

            //assert
            winner.Should().Be(p.ToWinner());
        }

        [Theory]
        [InlineData(Player.Circle)]
        [InlineData(Player.Cross)]
        public void GetWinner_Draw_ReturnsCorrectWinner(Player p)
        {
            // arrange
            var board = GetEmptyBoard();
            board[0][0].Value = TileValue.Cross;
            board[0][1].Value = TileValue.Circle;
            board[0][2].Value = TileValue.Cross;

            board[1][0].Value = TileValue.Circle;
            board[1][1].Value = TileValue.Cross;
            board[1][2].Value = TileValue.Circle;

            board[2][0].Value = TileValue.Circle;
            board[2][1].Value = TileValue.Cross;
            board[2][2].Value = TileValue.Circle;

            //act
            var winner = board.GetWinner(p);

            //assert
            winner.Should().Be(Winner.Draw);
        }

        [Theory]
        [InlineData(Player.Circle)]
        [InlineData(Player.Cross)]
        public void GetWinner_NoWinner_ReturnsCorrectWinner(Player p)
        {
            // arrange
            var board = GetEmptyBoard();
            board[0][0].Value = TileValue.Cross;
            board[0][1].Value = TileValue.Empty;
            board[0][2].Value = TileValue.Cross;

            board[1][0].Value = TileValue.Circle;
            board[1][1].Value = TileValue.Empty;
            board[1][2].Value = TileValue.Circle;

            board[2][0].Value = TileValue.Empty;
            board[2][1].Value = TileValue.Cross;
            board[2][2].Value = TileValue.Circle;

            //act
            var winner = board.GetWinner(p);

            //assert
            winner.Should().Be(Winner.None);
        }


        private SmallTileInformation[][] GetEmptyBoard()
        {
            var emptyBoard =  new SmallTileInformation[3][];

            for (int x = 0; x < 3; x++)
            {
                emptyBoard[x] = new SmallTileInformation[3];
                for (int y = 0; y < 3; y++)
                {
                    emptyBoard[x][y] = new SmallTileInformation
                    {
                        Value = TileValue.Empty,
                    };
                }
            }

            return emptyBoard;
        }
    }
}
