using System.Collections.Generic;
using System.Linq;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Domain
{
    internal static class BoardWinnerEvaluator
    {
        internal static Winner GetWinner(this TileInformation[][] tiles, Player lastPlayer)
        {
            if (HasPlayerWonAnyLine(tiles, lastPlayer))
            {
                return lastPlayer.ToWinner();
            }

            if (IsBoardFull(tiles))
            {
                return Winner.Draw;
            }

            return Winner.None;
        }

        private static bool HasPlayerWonAnyLine(TileInformation[][] tiles, Player p)
        {
            IEnumerable<IEnumerable<TileInformation>> lines = tiles.GetAllLinesOfBoard();
            return lines.Any(l => HasPlayerWonLine(l, p));
        }

        private static bool HasPlayerWonLine(IEnumerable<TileInformation> tilesInLine, Player p)
        {
            return tilesInLine.All(t => t.Value == p.ToTileValue());
        }

        private static bool IsBoardFull(TileInformation[][] tiles)
        {
            return !tiles.Any(t => t.Any(b => b.Value == TileValue.Empty));
        }
    }
}
