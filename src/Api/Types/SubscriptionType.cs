using HotChocolate.Types;

namespace UltimateTicTacToe.Api.Types
{
    public class SubscriptionType
        : ObjectType<Subscription>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Subscription> descriptor)
        {
        }
    }
}
