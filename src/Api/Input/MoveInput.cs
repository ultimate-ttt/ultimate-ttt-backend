using System;
using HotChocolate;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api
{
    public class MoveInput
    {
        public Guid GameId { get; set; }
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
