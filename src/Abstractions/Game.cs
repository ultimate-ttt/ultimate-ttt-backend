using System;

namespace UltimateTicTacToe.Abstractions
{
    public class Game
    {
        public string Id { get; set; }
        public Winner? Winner { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
