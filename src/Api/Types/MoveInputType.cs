using HotChocolate.Types;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Api.Input;

namespace UltimateTicTacToe.Api.Types
{
    public class MoveInputType : InputObjectType<MoveInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<MoveInput> descriptor)
        {
            descriptor
                .Field(m => m.GameId)
                .Type<NonNullType<IdType>>();

            descriptor
                .Field(m => m.Player)
                .Type<NonNullType<EnumType<Player>>>();

        }
    }
}
