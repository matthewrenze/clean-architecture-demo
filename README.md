# Clean Architecture Demo
A sample application for [Clean Architecture: Patterns, Practices, and Principles](https://pluralsight.pxf.io/clean-architecture) using Microsoft .NET 9.0.

This sample application is intended to be a learning tool for clean architecture practices. It incorporates several of these practices in a way that is simple and easy to understand.

If you'd like to learn more about this style of software architecture, please check out my online course [Clean Architecture: Patterns, Practices, and Principles](https://pluralsight.pxf.io/clean-architecture).

## Variations
There are three variations of this project to demonstrate various practices:

 - [main](https://github.com/matthewrenze/clean-architecture-demo/tree/main) - contains the simplest implementation used to demonstrate the practices taught in the course at the expense of a bit of coupling with the Entity Framework abstractions

 - [dbset-adaptor](https://github.com/matthewrenze/clean-architecture-demo/tree/dbset-adapter) - uses a database adapter to completely decouple the application from the persistence layer -- a cleaner but slightly more complex approach

 - [repo-and-uow](https://github.com/matthewrenze/clean-architecture-demo/tree/repo-and-uow) - uses the repository and unit of work patterns to completely decouple the application from the persistence layer -- an even cleaner but also more complex approach

## Technologies
This demo application uses the following technologies:
 - .NET Core 9.0
 - C# .NET 13.0
 - ASP.NET Core MVC 9.0
 - EF Core 9.0
 - Visual Studio 2022
 - SQL Server 2022
 - Scrutor 6.0
 - NUnit 4.3
 - Moq 4.20
 - SpecFlow 3.9

## Other Versions
For other versions of this sample application, please see the following:
 - [.NET 8.0](https://github.com/matthewrenze/clean-architecture-demo/tree/net8)
 - [.NET 6.0](https://github.com/matthewrenze/clean-architecture-demo/tree/net6)
 - [.NET 4.8](https://github.com/matthewrenze/clean-architecture-demo/tree/net48)
 - [.NET 4.5](https://github.com/matthewrenze/clean-architecture-demo/tree/net45)
