using HotChocolate.Types;

namespace UltimateTicTacToe.Api.Types
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Name("Mutation");
            descriptor.BindFields(BindingBehavior.Implicit);

            descriptor
                .Field(m => m.CreateGame(default, default))
                .Type<NonNullType<GameType>>();

            descriptor
                .Field(m => m.Move(default, default, default))
                .Argument("input", a => a.Type<NonNullType<MoveInputType>>())
                .Type<NonNullType<MoveResultType>>();
        }
    }
}
