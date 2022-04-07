using System;
using System.Net.Http;

namespace PrevisaoDoTempoApp.Http
{
    public static class ApiExtensions
    {
        public static HttpClient CreateHttpClient(string baseUrl)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            return httpClient;
        }
    }
}
