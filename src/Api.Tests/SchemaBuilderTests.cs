using Xunit;
using Snapshooter.Xunit;
using HotChocolate.Types;
using UltimateTicTacToe.Api.Types;

namespace UltimateTicTacToe.Api.Tests
{
    public class SchemaBuilderTests
    {
        [Fact]
        public void Ensure_Schema_IsCorrect()
        {
            // arrange
            var schema = SchemaBuilder.BuildSchema();

            // act
            string schemaSDL = schema.ToString();

            // assert
            Snapshot.Match(schemaSDL);
        }
    }
}
