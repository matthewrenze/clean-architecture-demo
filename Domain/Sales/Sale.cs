using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;

namespace CleanArchitecture.Domain.Sales
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public List<SaleLineItem> LineItems { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
