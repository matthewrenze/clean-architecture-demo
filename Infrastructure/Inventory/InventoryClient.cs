using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Infrastructure.Inventory
{
    public class InventoryClient 
        : IInventoryClient
    {
        public void NotifySaleOcurred(int productId, int quantity)
        {
            // Code to notify inventory microservice
        }
    }
}
