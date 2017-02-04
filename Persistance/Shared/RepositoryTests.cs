using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Domain.Sales;
using NUnit.Framework;

namespace CleanArchitecture.Persistance.Shared
{
    [TestFixture]
    public class RepositoryTests
    {
        private Repository<Sale> _repository;
        private AutoMoqer _mocker;
        private InMemoryDbSet<Sale> _sales;
        private Sale _sale;

        private const int SaleId = 1;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _sale = new Sale() { Id = SaleId };

            _sales = new InMemoryDbSet<Sale>() { _sale };

            _mocker.GetMock<IDatabaseContext>()
               .Setup(p => p.Set<Sale>())
               .Returns(_sales);
                        
            _repository = _mocker.Create<Repository<Sale>>();
        }

        [Test]
        public void TestGetAllShouldReturnAllEntities()
        {
            var results = _repository.GetAll();

            Assert.That(results,
                Contains.Item(_sale));
        }

        [Test]
        public void TestGetShouldReturnEntityById()
        {
            var result = _repository.Get(SaleId);

            Assert.That(result,
                Is.EqualTo(_sale));
        }

        [Test]
        public void TestAddShouldAddEntity()
        {
            _mocker.GetMock<IDatabaseContext>()
                .Setup(p => p.Sales)
                .Returns(new InMemoryDbSet<Sale>());

            _repository.Add(_sale);

            Assert.That(_sales,
                Contains.Item(_sale));
        }

        [Test]
        public void TestRemoveShouldRemoveEntity()
        {
            _repository.Remove(_sale);

            Assert.That(_sales,
                Is.Empty);
        }
    }
}
