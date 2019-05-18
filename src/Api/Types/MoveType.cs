using HotChocolate.Types;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api.Types
{
    public class MoveType : ObjectType<Move>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Move> descriptor)
        {
            descriptor
                .Field(m => m.Id)
                .Type<NonNullType<IdType>>();

            descriptor
                .Field(m => m.GameId)
                .Ignore();

            descriptor
                .Field(m => m.BoardPosition)
                .Type<NonNullType<PositionType>>();

            descriptor
                .Field(m => m.TilePosition)
                .Type<NonNullType<PositionType>>();

            descriptor
                .Field(m => m.Player)
                .Type<NonNullType<EnumType<Player>>>();

            descriptor
                .Field(m => m.MoveNumber)
                .Type<NonNullType<IntType>>();


        }
    }
}
