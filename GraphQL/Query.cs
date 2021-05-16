using System.Linq;
using GraphQueryTest.Data;
using GraphQueryTest.Models;
using HotChocolate;

namespace GraphQueryTest.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}