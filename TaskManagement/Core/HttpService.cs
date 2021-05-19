using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core
{
    public class HttpService
    {
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers, string payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(request);
            return response;
        }
    }
}