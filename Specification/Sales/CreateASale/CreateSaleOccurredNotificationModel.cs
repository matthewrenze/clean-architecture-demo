using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Specification.Sales.CreateASale
{
    public class CreateSaleOccurredNotificationModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
