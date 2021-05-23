using System.Linq;
using GraphQueryTest.Data;
using GraphQueryTest.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQueryTest.GraphQLs.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has commandline interface");

            descriptor
                .Field(p=>p.LicenseKey).Ignore();

            descriptor
                .Field(p=>p.Commands)
                .ResolveWith<Resolvers>(p=>p.GetCommands(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of available commands for the platform");    
        }

        private class Resolvers{
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context){
                return context.Commands.Where(p=>p.PlatformId == platform.Id);
            }
        }
        
    }
}