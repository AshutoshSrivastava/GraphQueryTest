using System.Linq;
using GraphQueryTest.Data;
using GraphQueryTest.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQueryTest.GraphQLs
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context) // this ScopedService is used for parallel query
        {
            return context.Platforms;
        }
    }
}