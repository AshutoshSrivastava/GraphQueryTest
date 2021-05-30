using GraphQueryTest.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQueryTest.Graphs
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform)
        {
            return platform;
        }
    }
}