using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Domain.Employees
{
    [TestFixture]
    public class EmployeeTests
    {
        private Employee _employee;
        private const int Id = 1;
        private const string Name = "Test";

        [SetUp]
        public void SetUp()
        {
            _employee = new Employee();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _employee.Id = Id;

            Assert.That(_employee.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _employee.Name = Name;

            Assert.That(_employee.Name,
                Is.EqualTo(Name));
        }
    }
}
