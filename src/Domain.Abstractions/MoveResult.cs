using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Domain.Abstractions
{
    public class MoveResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public Move Move { get; set; }
    }
}
