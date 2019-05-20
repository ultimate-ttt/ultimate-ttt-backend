using HotChocolate.Types;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api.Types
{
    public class PositionType : ObjectType<Position>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Position> descriptor)
        {
            descriptor
                .Field(m => m.X)
                .Type<NonNullType<IntType>>();

            descriptor
                .Field(m => m.X)
                .Type<NonNullType<IntType>>();
        }
    }
}
