using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Subscriptions;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api.Messages
{
    public class OnMoveMessage : EventMessage
    {
        public OnMoveMessage(Move move)
            : base(CreateEventDescription(move), move)
        {
        }

        private static EventDescription CreateEventDescription(Move move)
        {
            return new EventDescription("onMove",   new[] {
               new ArgumentNode("gameId", move.GameId),
                new ArgumentNode("player", new EnumValueNode( move.Player))

            });
        }
    }
}
