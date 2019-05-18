using HotChocolate;
using HotChocolate.Types;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api.Input
{
    public class MoveInput
    {
        [GraphQLNonNullType]
        public string GameId { get; set; }

        [GraphQLNonNullType]
        public Position BoardPosition { get; set; }

        [GraphQLNonNullType]
        public Position TilePosition { get; set; }

        [GraphQLNonNullType]
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
