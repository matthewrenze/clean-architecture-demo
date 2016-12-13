using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Specification.Sales.GetSaleDetails
{
    public class GetSaleDetailsModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Customer { get; set; }

        public string Employee { get; set; }

        public string Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
