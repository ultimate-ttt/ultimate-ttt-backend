using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using UltimateTicTacToe.Abstractions;
using UltimateTicTacToe.Data.Abstractions;

namespace UltimateTicTacToe.Data
{
    public static class DataServiceCollectionExtension
    {
        public static void AddDataServices(this IServiceCollection collection,
            IConfiguration configuration)
        {
            collection.AddTransient(s =>
                new MongoClient(configuration["Database:ConnectionString"])
                    .GetDatabase(configuration["Database:Name"]));

            collection.AddTransient(c => c
                .GetService<IMongoDatabase>()
                .GetCollection<Game>("games"));
            collection.AddTransient(c => c
                .GetService<IMongoDatabase>()
                .GetCollection<Move>("moves"));

            collection.AddSingleton<IGameRepository, GameRepository>();
            collection.AddSingleton<IMoveRepository, MoveRepository>();
        }
    }
}
