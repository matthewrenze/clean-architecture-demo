using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Network;

namespace CleanArchitecture.Infrastructure.Inventory
{
    public class InventoryClient 
        : IInventoryClient
    {
        // Note: these are hard coded to keep the demo simple
        private const string AddressTemplate = "http://abc.com/inventory/products/{0}/notifysaleoccured/";
        private const string JsonTemplate = "{{\"quantity\": {0}}}";

        private readonly IWebClientWrapper _client;

        public InventoryClient(IWebClientWrapper client)
        {
            _client = client;
        }

        public void NotifySaleOcurred(int productId, int quantity)
        {
            var address = string.Format(AddressTemplate, productId);

            var json = string.Format(JsonTemplate, quantity.ToString());

            _client.Post(address, json);
        }
    }
}
