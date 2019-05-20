using HotChocolate.Subscriptions;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api
{
    public class Subscription
    {
        public Move OnMove(IEventMessage message, string gameId, Player player)
        {
            return (Move)message.Payload;
        }
    }
}
