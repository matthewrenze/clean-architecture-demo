using System;
using System.Collections.Generic;
using System.Linq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
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
        private Employee _employee;

        private const int Id = 1;
        private const string Name = "Employee 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _employee = new Employee()
            {
                Id = Id,
                Name = Name
            };

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .ReturnsDbSet(new List<Employee> { _employee });

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
