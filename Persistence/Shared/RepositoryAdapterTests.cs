using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq.AutoMock;
using CleanArchitecture.Domain.Sales;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Shared
{
    [TestFixture]
    public class RepositoryAdapterTests
    {
        private RepositoryAdapter<Sale> _adapter;
        private AutoMocker _mocker;
        private Sale _sale;

        private const int Id = 1;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();
            
            _sale = new Sale();

            _adapter = _mocker.CreateInstance<RepositoryAdapter<Sale>>();
        }

        [Test]
        public void TestGetAllShouldReturnAllEntities()
        {
            var sales = new List<Sale> { _sale };

            _mocker.GetMock<IDbSet<Sale>>()
                .Setup(p => p.GetEnumerator())
                .Returns(sales.GetEnumerator());

            var results = _adapter.GetAll();

            Assert.That(results.ToList(),
                Contains.Item(_sale));
        }

        [Test]
        public void TestGetShouldReturnEntity()
        {
            _mocker.GetMock<IDbSet<Sale>>()
                .Setup(p => p.Find(Id))
                .Returns(_sale);
                
            var result = _adapter.Get(Id);

            Assert.That(result, 
                Is.EqualTo(_sale));
        }

        [Test]
        public void TestAddShouldAddEntity()
        {
            _adapter.Add(_sale);

            _mocker.GetMock<IDbSet<Sale>>()
                .Verify(p => p.Add(_sale),
                    Times.Once);
        }

        [Test]
        public void TestRemoveShouldRemoveEntity()
        {
            _adapter.Remove(_sale);

            _mocker.GetMock<IDbSet<Sale>>()
                .Verify(p => p.Remove(_sale),
                    Times.Once);
        }
    }
}
