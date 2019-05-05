namespace UltimateTicTacToe.Abstractions
{
    public abstract class TileInformation
    {
        public Position Position { get; set; }
        public TileValue Value { get; set; }
    }
}
