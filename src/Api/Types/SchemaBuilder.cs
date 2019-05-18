using HotChocolate;

namespace UltimateTicTacToe.Api.Types
{
    public class SchemaBuilder
    {
        public static Schema BuildSchema()
        {
            return Schema.Create(c =>
            {
                //GraphQL Types
                c.RegisterQueryType<QueryType>();
                c.RegisterMutationType<MutationType>();
                // c.RegisterSubscriptionType<SubscriptionType>();
                c.RegisterExtendedScalarTypes();

                //Custom Types
                c.RegisterType<GameType>();
                c.RegisterType<MoveType>();
                c.RegisterType<PositionType>();
                c.RegisterType<MoveResultType>();
            });
        }
    }
}
