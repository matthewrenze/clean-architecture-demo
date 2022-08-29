using Moq.AutoMock;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Shared
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private UnitOfWork _unitOfWork;
        private AutoMocker _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _unitOfWork = _mocker.CreateInstance<UnitOfWork>();
        }

        [Test]
        public void TestSaveShouldSaveUnitOfWork()
        {
            _unitOfWork.Save();
        }
    }
}
