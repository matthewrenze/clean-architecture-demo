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
    public class InventoryClientTests
    {
        private InventoryClient _client;
        private AutoMoqer _mocker;

        private const string Address = "http://abc.com/inventory/products/1/notifysaleoccured/";
        private const string Json = "{\"quantity\": 2}";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _client = _mocker.Create<InventoryClient>();
        }

        [Test]
        public void TestNotifySaleOccuredShouldNotifyInventorySystem()
        {
            _client.NotifySaleOcurred(1, 2);

            _mocker.GetMock<IWebClientWrapper>()
                .Verify(p => p.Post(Address, Json),
                    Times.Once);
        }
    }
}
