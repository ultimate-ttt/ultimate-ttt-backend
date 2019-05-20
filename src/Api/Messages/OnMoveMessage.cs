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
            return new EventDescription("onMove"/*,   new[] {
               new ArgumentNode("GameId", move.GameId),
                new ArgumentNode("Player", new EnumValueNode( move.Player))

            }*/);
        }
    }
}
