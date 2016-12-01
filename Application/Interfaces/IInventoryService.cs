using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IInventoryService
    {
        void NotifySaleOcurred(int productId, int quantity);
    }
}
