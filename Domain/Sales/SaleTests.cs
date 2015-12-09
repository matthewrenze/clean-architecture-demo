using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CleanArchitecture.Domain.Sales
{
    [TestFixture]
    public class SaleTests
    {
        private Sale _sale;

        private const decimal UnitPrice = 1.00m;
        private const int Quantity = 1;

        [SetUp]
        public void SetUp()
        {
            _sale = new Sale()
            {
                UnitPrice = UnitPrice,
                Quantity = Quantity
            };
        }

        [Test]
        public void TestSetUnitPriceShouldRecomputeTotalPrice()
        {
            _sale.UnitPrice = 1.23m;

            Assert.That(_sale.TotalPrice, Is.EqualTo(1.23));
        }

        [Test]
        public void TestSetQuantityShouldRecomputeTotalPrice()
        {
            _sale.Quantity = 2;

            Assert.That(_sale.TotalPrice, Is.EqualTo(2.00m));
        }
    }
}
