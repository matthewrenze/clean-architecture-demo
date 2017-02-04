using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Employees;
using NUnit.Framework;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployeesList
{
    [TestFixture]
    public class GetEmployeesListQueryTests
    {
        private GetEmployeesListQuery _query;
        private AutoMoqer _mocker;
        private List<Employee> _employees;
        private Employee _employee;

        private const int Id = 1;
        private const string Name = "Employee 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _employee = new Employee()
            {
                Id = Id,
                Name = Name
            };

            _employees = new List<Employee>()
            {
                _employee
            };

            _mocker.GetMock<IEmployeeRepository>()
                .Setup(p => p.GetAll())
                .Returns(_employees.AsQueryable());

            _query = _mocker.Create<GetEmployeesListQuery>();
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
