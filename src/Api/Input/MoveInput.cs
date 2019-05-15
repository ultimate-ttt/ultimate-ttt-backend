using HotChocolate;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api.Input
{
    public class MoveInput
    {
        public string GameId { get; set; }
        public Position BoardPosition { get; set; }
        public Position TilePosition { get; set; }
        public Player Player { get; set; }

        [GraphQLIgnore]
        public Move ToMove()
        {
            return new Move
            {
                Player = Player,
                GameId = GameId,
                TilePosition = TilePosition,
                BoardPosition = BoardPosition
            };
        }
    }
}
