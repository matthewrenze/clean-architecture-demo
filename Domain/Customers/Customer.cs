using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
