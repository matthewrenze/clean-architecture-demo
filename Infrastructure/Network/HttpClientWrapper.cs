using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;

namespace CleanArchitecture.Infrastructure.Network
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public void Post(string address, string json)
        {
            using var client = new HttpClient();

            // Note: This next line is commented out to prevent an
            // Note: actual HTTP call, since this is just a demo app.

            // client.PostAsJsonAsync(address, json);
        }
    }
}
