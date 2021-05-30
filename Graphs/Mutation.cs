using System.Threading.Tasks;
using GraphQueryTest.Data;
using GraphQueryTest.Graphs.Commands;
using GraphQueryTest.Graphs.Platforms;
using GraphQueryTest.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQueryTest.Graphs
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,[ScopedService] AppDbContext context)
        {
            var platform = new Platform{
                Name = input.Name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,[ScopedService] AppDbContext context)
        {
            var command = new Command{
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}