using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq.AutoMock;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Employees;
using NUnit.Framework;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployeesList
{
    [TestFixture]
    public class GetEmployeesListQueryTests
    {
        private GetEmployeesListQuery _query;
        private AutoMocker _mocker;

        private const int Id = 1;
        private const string Name = "Employee 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            var employee = new Employee()
            {
                Id = Id,
                Name = Name
            };

            var employees = new List<Employee>()
            {
                employee
            };

            _mocker.GetMock<IRepository<Employee>>()
                .Setup(p => p.GetAll())
                .Returns(employees.AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .Returns(_mocker.GetMock<IRepository<Employee>>().Object);

            _query = _mocker.CreateInstance<GetEmployeesListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfEmployees()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
