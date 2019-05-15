using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Domain.Abstractions
{
    public class MoveResult
    {
        public bool IsValid { get; set; }
        public Move Move { get; set; }

        public string InvalidReason { get; set; }

        public bool MoveFinishedBoard { get; set; }
        public bool MoveFinishedGame { get; set; }
    }
}
