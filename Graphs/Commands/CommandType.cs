using System.Linq;
using GraphQueryTest.Data;
using GraphQueryTest.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQueryTest.Graphs.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor){
            descriptor.Description("Represents Any executable command");

            descriptor
                .Field(c=>c.PlatformId)
                .ResolveWith<Resolvers>(c=>c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform to which the commands belong");
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context){
                return context.Platforms.FirstOrDefault(p=>p.Id==command.PlatformId);
            }
        }
        
    }
}