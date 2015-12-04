using System;

namespace CleanArchitecture.Application.Sales.Queries.GetSaleDetails
{
    public class SaleDetailModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}