## Add hotchocolate :
* dotnet add package HotChocolate.AspNetCore
* dotnet add package HotChocolate.Data.EntityFramework

## Microsoft Entity
* dotnet add package Microsoft.EntityframeworkCore.Design
* dotnet add package Microsoft.EntityframeworkCore.SQLServer

#### Later
* dotnet add package GraphQL.Server.Ui.Voyager

# Run Docker Image
* docker-compose up -d

# Install EF
* dotnet tool install --global dotnet-ef

## Add Migration
* dotnet ef migrations add AddPlatformToDb

## For Adding Filtering and Sorting
        
* Query.cs        
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context) // this ScopedService is used for parallel query
        {
            return context.Platforms;
        }
* Startup.cs
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddProjections() // for pulling child objects
                .AddFiltering() // for filtering
                .AddSorting()   //for sorting
                ;
* Filtering :
query{
  platform(order: {name: ASC})
  {
    id
    name
    commands
    {
      commandLine
      howTo
      id
    }
  }
}

* Sorting :
query{
  platform(order: {name: ASC})
  {
    name
  }
}

        