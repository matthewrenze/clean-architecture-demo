using System;

namespace CleanArchitecture.Application.Sales.Queries.GetSalesQuery
{
    public class SalesListModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public int ItemCount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
