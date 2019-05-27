using HotChocolate.Types;
using UltimateTicTacToe.Domain.Abstractions;

namespace UltimateTicTacToe.Api.Types
{
    public class MoveResultType : ObjectType<MoveResult>
    {
        protected override void Configure(
            IObjectTypeDescriptor<MoveResult> descriptor)
        {
            descriptor
                .Field(m => m.IsValid)
                .Type<NonNullType<BooleanType>>();

            descriptor
                .Field(m => m.Move)
                .Type<NonNullType<MoveType>>();

            descriptor
                .Field(m => m.InvalidReason)
                .Type<StringType>();

            descriptor
                .Field(m => m.MoveFinishedBoard)
                .Type<NonNullType<BooleanType>>();

            descriptor
                .Field(m => m.MoveFinishedGame)
                .Type<NonNullType<BooleanType>>();
        }
    }
}
