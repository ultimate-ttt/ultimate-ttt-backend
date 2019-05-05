using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace UltimateTicTacToe.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();
        }

        private static void SetupConfiguration(
            WebHostBuilderContext builderContext,
            IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
#if DEBUG
            builder.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
#endif
            builder.AddEnvironmentVariables();
        }
    }
}
