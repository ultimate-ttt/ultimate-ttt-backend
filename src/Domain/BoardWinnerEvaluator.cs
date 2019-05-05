using System.Collections.Generic;
using System.Linq;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Domain
{
    internal class BoardWinnerEvaluator
    {
        private readonly TileInformation[][] _tiles;

        internal BoardWinnerEvaluator(TileInformation[][] tiles)
        {
            _tiles = tiles;
        }

        internal Winner GetWinner(Player lastPlayer)
        {
            if (HasPlayerWonAnyLine(lastPlayer)) return lastPlayer.ToWinner();

            if (IsBoardFull()) return Winner.Draw;

            return Winner.None;
        }

        private bool HasPlayerWonAnyLine(Player p)
        {
            IEnumerable<IEnumerable<TileInformation>> lines = _tiles.GetAllLinesOfBoard();
            return lines.Any(l => HasPlayerWonLine(l, p));
        }

        private bool HasPlayerWonLine(IEnumerable<TileInformation> tilesInLine, Player p)
        {
            return tilesInLine.All(t => t.Value == p.ToTileValue());
        }

        private bool IsBoardFull()
        {
            return !_tiles.Any(t => t.Any(b => b.Value == TileValue.Empty));
        }
    }
}
