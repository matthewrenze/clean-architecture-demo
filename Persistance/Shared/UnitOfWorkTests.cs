using AutoMoq;
using NUnit.Framework;

namespace CleanArchitecture.Persistance.Shared
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private UnitOfWork _unitOfWork;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _unitOfWork = _mocker.Create<UnitOfWork>();
        }

        [Test]
        public void TestSaveShouldSaveUnitOfWork()
        {
            _unitOfWork.Save();
        }
    }
}
