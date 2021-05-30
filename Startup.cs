using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GraphQueryTest.Data;
using GraphQueryTest.Graphs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server.Ui.Voyager;
using GraphQueryTest.Graphs.Platforms;
using GraphQueryTest.Graphs.Commands;

namespace GraphQueryTest
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public static string DockerHostMachineIpAddress => Dns.GetHostAddresses(new Uri("http://docker.for.win.localhost").Host)[0].ToString();
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // AddPooledDbContextFactory is used for parallel query
            services.AddPooledDbContextFactory<AppDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("CommandsConStr")
                // .Replace("localhost",DockerHostMachineIpAddress)
                );
            });

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>() // for subscription
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddProjections() // for pulling child objects
                .AddFiltering() // for filtering
                .AddSorting()   //for sorting
                .AddInMemorySubscriptions() // for subscription manage memory of subscribers
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     // await context.Response.WriteAsync("Hello World!");
                //     endpoints.MapGraphQL();
                // });

                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQL.Server.Ui.Voyager.VoyagerOptions() // GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
                // Path = "graphql-voyager"
            });
        }
    }
}
