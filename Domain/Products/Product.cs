using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Products
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
