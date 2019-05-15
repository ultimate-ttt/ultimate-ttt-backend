using HotChocolate.Types;

namespace UltimateTicTacToe.Api.Types
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Name("Mutation");
            descriptor.BindFields(BindingBehavior.Implicit);
        }
    }
}
