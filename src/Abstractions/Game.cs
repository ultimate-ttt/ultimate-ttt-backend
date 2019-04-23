using System;

namespace UltimateTicTacToe.Abstractions
{
    public class Game
    {
        public string Id { get; set; }
        public Player? Winner { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
