using System;

namespace CleanArchitecture.Application.Sales.Queries.GetSalesList
{
    public class SalesListItemDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int ItemCount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
