using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Infrastructure.Network;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace CleanArchitecture.Infrastructure.Inventory
{
    [TestFixture]
    public class InventoryServiceTests
    {
        private InventoryService _service;
        private AutoMocker _mocker;

        private const string Address = "http://abc123.com/inventory/products/1/notifysaleoccured/";
        private const string Json = "{\"quantity\": 2}";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _service = _mocker.CreateInstance<InventoryService>();
        }

        [Test]
        public void TestNotifySaleOccurredShouldNotifyInventorySystem()
        {
            _service.NotifySaleOccurred(1, 2);

            _mocker.GetMock<IWebClientWrapper>()
                .Verify(p => p.Post(Address, Json),
                    Times.Once);
        }
    }
}
