using System.Linq;
using GraphQueryTest.Data;
using GraphQueryTest.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQueryTest.Graphs
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection] // pull child object too
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context) // this ScopedService is used for parallel query
        {
            return context.Platforms;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection] // pull child object too
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context) // this ScopedService is used for parallel query
        {
            return context.Commands;
        }
    }
}