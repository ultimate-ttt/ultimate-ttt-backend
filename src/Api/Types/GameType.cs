using System;
using HotChocolate.Types;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;

namespace UltimateTicTacToe.Api.Types
{
    public class GameType : ObjectType<Game>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Game> descriptor)
        {
            descriptor
                .Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor
                .Field("moves")
                .Type<NonNullType<ListType<NonNullType<MoveType>>>>()
                .Resolver(async r =>
                {
                    Guid gameId = r.Parent<Game>().Id;
                    IMoveRepository moveRepository = r.Service<IMoveRepository>();

                    return await moveRepository.GetMovesForGame(gameId, r.RequestAborted);
                });
        }
    }

    public class MoveType : ObjectType<Move>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Move> descriptor)
        {
        }
    }
}
