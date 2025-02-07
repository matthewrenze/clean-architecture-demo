using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Specification.Sales.CreateASale
{
    public class CreateSaleInfoModel
    {
        public DateTime Date { get; set; }

        public string Customer { get; set; } = string.Empty;

        public string Employee { get; set; } = string.Empty;

        public string Product { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}
