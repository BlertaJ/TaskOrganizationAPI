# Task Organization API

***
 The project will give the opportunity to manage tasks of projects.
 
 You have the opportunity to create a new project, then insert the tasks for the project and all data will be mapped correctly based on requirements.

***

## Technologies
***
* ASP.NET Core 6
* Entity Framework
* MediatR
* AutoMapper
* Entity Framework
* NUnit, FluentAssertions

## Database Configuration
***
Verify that the DefaultConnection connection string within appsettings.json points to a valid SQL Server instance.

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.


## Database Migrations
***
To add a new migration from the root folder:
```
dotnet ef migrations add "InitialMigrationTest" --project ./Infrastructure --startup-project ./TaskOrganizationAPI --output-dir Persistence\Migrations
```

## Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

## Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

## Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

## TaskOrganizationAPI  
The API-s where the data will be returned with the specified mapped DTO-s.

The API-s where the data will be inserted also with the specified mapped DTO-s.
