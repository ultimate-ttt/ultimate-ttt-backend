using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using UltimateTicTacToe.Domain;
using UltimateTicTacToe.Domain.Abstractions;
using Xunit;

namespace Domain.Tests
{
    public class DomainServiceCollectionExtensionTests
    {
        [Fact]
        public void AddDomainServices_ValidServiceCollection_AddsIGameManager()
        {
            // arrange
            ServiceCollection sc = new ServiceCollection();

            // act
            sc.AddDomainServices();

            // assert
            var gameManager = sc.BuildServiceProvider().GetService<IGameManager>();
            gameManager.Should().NotBeNull();
        }

    }
}
