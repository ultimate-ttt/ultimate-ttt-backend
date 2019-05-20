using HotChocolate.Subscriptions;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api
{
    public class Subscription
    {
        public Move onMove(IEventMessage message)
        {
            return (Move)message.Payload;
        }
    }
}
