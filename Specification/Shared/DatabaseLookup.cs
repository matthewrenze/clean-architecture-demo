using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Specification.Shared
{
    public class DatabaseLookup
    {
        private readonly IDatabaseService _database;

        public DatabaseLookup(IDatabaseService database)
        {
            _database = database;
        }

        public int GetCustomerId(string name)
        {
            return _database.Customers
                .Single(p => p.Name == name).Id;
        }

        public int GetEmployeeId(string name)
        {
            return _database.Employees
                .Single(p => p.Name == name).Id;
        }

        public int GetProductIdByName(string name)
        {
            return _database.Products
                .Single(p => p.Name == name).Id;
        }
    }
}
