using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Employees
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
