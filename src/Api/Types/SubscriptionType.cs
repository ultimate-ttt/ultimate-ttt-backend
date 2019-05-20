using HotChocolate.Types;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api.Types
{
    public class SubscriptionType
        : ObjectType<Subscription>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Subscription> descriptor)
        {
            descriptor
                .Field(s => s.OnMove(default, default, default))
                .Argument("gameId", a => a.Type<NonNullType<StringType>>())
                .Argument("player", a => a.Type<NonNullType<EnumType<Player>>>())
                .Type<NonNullType<MoveType>>();
        }
    }
}
