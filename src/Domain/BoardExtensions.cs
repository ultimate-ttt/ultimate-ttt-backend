using System.Collections.Generic;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Domain
{
    internal static class BoardExtensions
    {
        internal static IEnumerable<IEnumerable<TileInformation>> GetAllLinesOfBoard(
            this TileInformation[][] tiles
        )
        {
            for (int x = 0; x < 3; x++)
            {
                List<TileInformation> lineHorizontal = new List<TileInformation>(3);
                List<TileInformation> lineVertical = new List<TileInformation>(3);
                for (int y = 0; y < 3; y++)
                {
                    lineHorizontal.Add(tiles[x][y]);
                    lineVertical.Add(tiles[y][x]);
                }

                yield return lineHorizontal;
                yield return lineVertical;
            }

            // diagonals
            yield return new List<TileInformation> {tiles[0][0], tiles[1][1], tiles[2][2]};
            yield return new List<TileInformation> {tiles[2][0], tiles[1][1], tiles[0][2]};
        }
    }
}
