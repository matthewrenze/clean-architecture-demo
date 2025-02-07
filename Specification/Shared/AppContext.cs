using System;
using System.Collections.Generic;
using System.Linq;
using Moq.AutoMock;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Dates;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Specification.Shared
{
    public class AppContext
    {
        public AutoMocker Mocker;
        public IServiceProvider Container;
        public IDatabaseService DatabaseService;
        public IInventoryService InventoryService;
        public IDateService DateService;

        public AppContext()
        {
            Mocker = new AutoMocker();

            var options = new DbContextOptionsBuilder<MockDatabaseService>()
                .UseInMemoryDatabase(databaseName: "CleanArchitectureInMemory")
                .Options;

            DatabaseService = new MockDatabaseService(options);                   

            InventoryService =  Mocker.GetMock<IInventoryService>().Object;

            var mockDateService = Mocker.GetMock<IDateService>();

            mockDateService
                .Setup(p => p.GetDate())
                .Returns(DateTime.Parse("2001-02-03"));

            DateService = mockDateService.Object;

            var files = Directory.GetFiles(
                AppDomain.CurrentDomain.BaseDirectory,
                "CleanArchitecture*.dll");

            var assemblies = files
                .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

            var provider = new ServiceCollection()
                .Scan(p => p.FromAssemblies(assemblies)
                    .AddClasses()
                    .AsMatchingInterface())
                .AddSingleton(_ => DatabaseService)
                .AddSingleton(_ => InventoryService)
                .AddSingleton(_ => DateService)
                .BuildServiceProvider();

            Container = provider;
        }
    }
}
