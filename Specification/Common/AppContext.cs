using System;
using System.Collections.Generic;
using System.Linq;
using Moq.AutoMock;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Dates;
using StructureMap;

namespace CleanArchitecture.Specification.Common
{
    public class AppContext
    {
        public AutoMocker Mocker;
        public IContainer Container;
        public IDatabaseService DatabaseService;
        public IInventoryService InventoryService;
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
            Mocker = new AutoMocker();
        }

        public void SetUpMockDatabase()
        {
            var mockDatabase = Mocker.GetMock<IDatabaseService>();

            var intitializer = new DatabaseInitializer(mockDatabase);

            intitializer.Seed();

            DatabaseService = mockDatabase.Object;
        }

        private void SetUpMockInventoryClient()
        {
            InventoryService =  Mocker.GetMock<IInventoryService>().Object;
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
