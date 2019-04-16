using System;

namespace UltimateTicTacToe.Abstractions
{
    public class Move
    {
        public Guid GameId { get; set; }
        public Position BoardPosition { get; set; }
        public Position TilePosition { get; set; }
        public Player Player { get; set; }
        public int MoveNumber { get; set; }
    }
}
