using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Specification.Sales.CreateASale
{
    public class CreateSaleInfoModel
    {
        public DateTime Date { get; set; }

        public string Customer { get; set; }

        public string Employee { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }
    }
}
