using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq.AutoMock;
using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;
using NUnit.Framework;

namespace CleanArchitecture.Service.Employees
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        private EmployeesController _controller;
        private AutoMocker _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _controller = _mocker.CreateInstance<EmployeesController>();
        }

        [Test]
        public void TestGetEmployeesListShouldReturnListOfEmployees()
        {
            var employee = new EmployeeModel();

            _mocker.GetMock<IGetEmployeesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<EmployeeModel> {employee});

            var results = _controller.Get();

            Assert.That(results,
                Contains.Item(employee));
        }
    }
}