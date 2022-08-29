# Clean Architecture Demo
A sample application for [Clean Architecture: Patterns, Practices, and Principles](https://pluralsight.pxf.io/clean-architecture) using Microsoft .NET Framework 4.8.

This sample application is intended to be a learning tool for clean architecture practices. It incorporates several of these practices in a way that is simple and easy to understand.

If you'd like to learn more about this style of software architecture, please check out my online course [Clean Architecture: Patterns, Practices, and Principles](https://pluralsight.pxf.io/clean-architecture).

## Branches
There are three branches in this project to demonstrate various practices:

 - [master](https://github.com/matthewrenze/clean-architecture-demo/tree/master) - contains the simplest implementation used to demonstrate the practices taught in the course at the expense of a bit of coupling with the IDbSet interface from Entity Framework

 - [dbset-adaptor](https://github.com/matthewrenze/clean-architecture-demo/tree/dbset-adapter) - uses a database adapter to completely decouple the application from the persistence layer -- a cleaner but slightly more complex approach

 - [repo-and-uow](https://github.com/matthewrenze/clean-architecture-demo/tree/repo-and-uow) - uses the repository and unit of work patterns to completely decouple the application from the persistance layer -- an even cleaner but also more complex approach

## Technologies
This demo application uses the following technologies:
 - .NET Framework 4.8
 - C# .NET 7.3
 - ASP.NET MVC 5.2
 - Entity Framework 6.4
 - Visual Studio 2022
 - SQL Server 2019
 - StructureMap 4.7
 - NUnit 3.13
 - Moq 4.18
 - SpecFlow 3.9

## Other Versions
For other versions of this sample application, please see the following:
 - [.NET Core 6.0](https://github.com/matthewrenze/clean-architecture-core)
 - [.NET Framework 4.5](https://github.com/matthewrenze/clean-architecture-demo/tree/v4.5)