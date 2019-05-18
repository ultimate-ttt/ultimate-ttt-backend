using HotChocolate.Types;

namespace UltimateTicTacToe.Api.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Name("Query");
            descriptor.BindFields(BindingBehavior.Implicit);

            descriptor.Field(q => q.GetGame(default, default, default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());
        }
    }
}
