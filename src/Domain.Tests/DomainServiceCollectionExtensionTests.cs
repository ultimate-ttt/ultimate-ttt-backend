using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using UltimateTicTacToe.Data.Abstractions;
using UltimateTicTacToe.Domain.Abstractions;
using Xunit;

namespace UltimateTicTacToe.Domain.Tests
{
    public class DomainServiceCollectionExtensionTests
    {
        [Fact]
        public void AddDomainServices_ValidServiceCollection_AddsIGameManager()
        {
            // arrange
            var sc = new ServiceCollection();
            sc.AddSingleton(Mock.Of<IGameRepository>());
            sc.AddSingleton(Mock.Of<IMoveRepository>());

            // act
            sc.AddDomainServices();

            // assert
            var gameManager = sc.BuildServiceProvider().GetService<IGameManager>();
            gameManager.Should().NotBeNull();
        }

        [Fact]
        public void AddDomainServices_ValidServiceCollection_AddsMoveValidator()
        {
            // arrange
            var sc = new ServiceCollection();
            sc.AddSingleton(Mock.Of<IGameRepository>());
            sc.AddSingleton(Mock.Of<IMoveRepository>());

            // act
            sc.AddDomainServices();

            // assert
            var validator = sc.BuildServiceProvider().GetService<IMoveValidator>();
            validator.Should().NotBeNull();
        }
    }
}
