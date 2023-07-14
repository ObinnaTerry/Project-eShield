using System.Net.Http.Headers;

namespace ProxyService.Services
{
    public class HttpClientService
    {
        public HttpClient Client { get; }
        static readonly string url = "http://localhost";

        public HttpClientService(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(3);
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client = client;
        }
    }
}
