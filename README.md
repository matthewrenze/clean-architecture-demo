# Clean Architecture Demo
A sample application for [Clean Architecture: Patterns, Practices, and Principles](https://pluralsight.pxf.io/clean-architecture) using Microsoft .NET Framework 4.5.

This sample application is intended to be a learning tool for clean architecture practices. It incorporates several of these practices in a way that is simple and easy to understand.

If you'd like to learn more about this style of software architecture, please check out my online course [Clean Architecture: Patterns, Practices, and Principles](https://pluralsight.pxf.io/clean-architecture).

## Variations
There are three variations of this project to demonstrate various practices:

 - [main](https://github.com/matthewrenze/clean-architecture-demo/tree/main) - contains the simplest implementation used to demonstrate the practices taught in the course at the expense of a bit of coupling with the Entity Framework abstractions

 - [dbset-adaptor](https://github.com/matthewrenze/clean-architecture-demo/tree/dbset-adapter) - uses a database adapter to completely decouple the application from the persistence layer -- a cleaner but slightly more complex approach

 - [repo-and-uow](https://github.com/matthewrenze/clean-architecture-demo/tree/repo-and-uow) - uses the repository and unit of work patterns to completely decouple the application from the persistance layer -- an even cleaner but also more complex approach

## Technologies
This demo application uses the following technologies:
 - .NET Framework 4.5
 - C# .NET 7.3
 - ASP.NET MVC 4.5
 - Entity Framework 5
 - Visual Studio 2015
 - SQL Server 2014
 - StructureMap 3.1
 - NUnit 3.0
 - Moq 4.2
 - SpecFlow 2.1

## Other Versions
For all other versions of this sample application, please see the [readme.md](https://github.com/matthewrenze/clean-architecture-demo/blob/main/README.md) in the main repository.