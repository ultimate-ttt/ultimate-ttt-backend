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
using SchemaBuilder = UltimateTicTacToe.Api.Types.SchemaBuilder;

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

            Schema schema = SchemaBuilder.BuildSchema();

            services.AddGraphQL(schema.MakeExecutable(c =>
                c.UseDefaultPipeline(new QueryExecutionOptions
                {
#if DEBUG
                    TracingPreference = TracingPreference.Always,
                    IncludeExceptionDetails = true
#endif
                })
                    .AddCustomErrorFilters()));
            services.AddInMemorySubscriptionProvider();
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
