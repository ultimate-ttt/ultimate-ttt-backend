using HotChocolate.Types;
using UltimateTicTacToe.Abstractions;

namespace UltimateTicTacToe.Api.Types
{
    public class MoveType : ObjectType<Move>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Move> descriptor)
        {
        }
    }
}
