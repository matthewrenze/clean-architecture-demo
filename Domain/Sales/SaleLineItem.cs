using System;
using CleanArchitecture.Domain.Products;

namespace CleanArchitecture.Domain.Sales
{
    public class SaleLineItem
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
