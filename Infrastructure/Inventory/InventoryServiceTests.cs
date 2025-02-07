using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Infrastructure.Network;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Infrastructure.Inventory
{
    [TestFixture]
    public class InventoryServiceTests
    {
        private InventoryService _service;
        private AutoMoqer _mocker;

        private const string Address = "http://abc123.com/inventory/products/1/notifysaleoccured/";
        private const string Json = "{\"quantity\": 2}";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _service = _mocker.Create<InventoryService>();
        }

        [Test]
        public void TestNotifySaleOccuredShouldNotifyInventorySystem()
        {
            _service.NotifySaleOcurred(1, 2);

            _mocker.GetMock<IWebClientWrapper>()
                .Verify(p => p.Post(Address, Json),
                    Times.Once);
        }
    }
}
