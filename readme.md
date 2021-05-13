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