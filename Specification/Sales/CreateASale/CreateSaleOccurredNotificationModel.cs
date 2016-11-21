using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Specification.Sales.CreateASale
{
    public class CreateSaleOccurredNotificationModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
