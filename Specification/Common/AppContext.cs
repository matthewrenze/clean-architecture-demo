using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Dates;
using Moq;
using StructureMap;

namespace CleanArchitecture.Specification.Common
{
    public class AppContext
    {
        public AutoMoqer Mocker;
        public IContainer Container;
        public IDatabaseContext Database;
        public IInventoryClient InventoryClient;
        public IDateService DateService;

        public AppContext()
        {
            SetUpAutoMocker();

            SetUpMockDatabase();

            SetUpMockInventoryClient();

            SetUpMockDateService();

            SetUpIocContainer();
        }

        private void SetUpAutoMocker()
        {
            Mocker = new AutoMoqer();
        }

        public void SetUpMockDatabase()
        {
            var mockDatabase = Mocker.GetMock<IDatabaseContext>();

            var intitializer = new DatabaseInitializer(mockDatabase);

            intitializer.Seed();

            Database = mockDatabase.Object;
        }

        private void SetUpMockInventoryClient()
        {
            InventoryClient =  Mocker.GetMock<IInventoryClient>().Object;
        }

        private void SetUpMockDateService()
        {
            var mockDateService = Mocker.GetMock<IDateService>();

            mockDateService
                .Setup(p => p.GetDate())
                .Returns(DateTime.Now);

            DateService = mockDateService.Object;
        }

        private void SetUpIocContainer()
        {
            Container = IoC.Initialize(this);
        }
    }
}
