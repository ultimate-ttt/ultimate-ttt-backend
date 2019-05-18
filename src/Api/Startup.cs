using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltimateTicTacToe.Api.ErrorFilters;
using UltimateTicTacToe.Api.Types;
using UltimateTicTacToe.Data;
using UltimateTicTacToe.Domain;

namespace UltimateTicTacToe.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataServices(Configuration);
            services.AddDomainServices();

            //services.AddInMemorySubscriptionProvider();

            Schema schema = Schema.Create(c =>
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

            services.AddGraphQL(schema.MakeExecutable(c =>
                c.UseDefaultPipeline(new QueryExecutionOptions
                    {
#if DEBUG
                        TracingPreference = TracingPreference.Always,
                        IncludeExceptionDetails = true
#endif
                    })
                    .AddCustomErrorFilters()));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets()
                .UseGraphQL()
                .UsePlayground();
        }
    }
}
