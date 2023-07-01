using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Serilog;

namespace ProxyService
{
    internal class ProxyServer
    {
        private static readonly ILogger _logger = Log.ForContext<ProxyServer>();

        public static async Task StartProxyServerAsync()
        {
            string wifiIpAddress = GetWifiIpAddress();
            if (wifiIpAddress == null)
            {
                _logger.Error("Failed to retrieve Wi-Fi IP address.");
                return;
            }

            int proxyPort = 8080;
            string proxyUrl = $"http://{wifiIpAddress}:{proxyPort}/";
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(proxyUrl);
            listener.Start();
            _logger.Information($"Proxy server started on {proxyUrl}");

            // Create an HTTP listener on the desired proxy port
            //int proxyPort = 8080;
            ////string proxyUrl = $"http://localhost:{proxyPort}/";
            //string proxyUrl = $"http://*:{proxyPort}/";
            //HttpListener listener = new HttpListener();
            //listener.Prefixes.Add(proxyUrl);
            //listener.Start();
            //_logger.Information($"Proxy server started on {proxyUrl}");

            try
            {
                while (true)
                {
                    // Accept incoming HTTP client requests asynchronously
                    HttpListenerContext context = await listener.GetContextAsync();

                    // Handle each client request concurrently
                    Task.Run(() => HandleClientAsync(context));
                }
            }
            finally
            {
                listener.Stop();
            }
        }

        private static async Task HandleClientAsync(HttpListenerContext context)
        {
            try
            {
                string clientIpAddress = context.Request.RemoteEndPoint.Address.ToString();
                _logger.Information(clientIpAddress);

                // Read the request headers
                WebHeaderCollection headers = (WebHeaderCollection)context.Request.Headers;

                // Read specific header values
                string userAgent = headers["User-Agent"];
                string contentType = headers["Content-Type"];

                // Read the destination URL and port
                string destinationUrl = context.Request.Url.ToString();
                int destinationPort = context.Request.Url.Port;

                // Read the client's request body
                using (StreamReader reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                {
                    string request = await reader.ReadToEndAsync();

                    // Create HttpClient instance
                    using (HttpClient httpClient = new HttpClient())
                    {
                        // Forward the request to the target server
                        HttpResponseMessage response = await httpClient.PostAsync(destinationUrl, new StringContent(request));

                        // Read the response from the target server
                        byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

                        // Forward the response to the client
                        context.Response.ContentLength64 = responseBytes.Length;
                        await context.Response.OutputStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the proxying process
                Console.WriteLine($"Error: {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            finally
            {
                context.Response.OutputStream.Close();
            }
        }

        private static string? GetWifiIpAddress()
        {
            NetworkInterface wifiInterface = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(i => i.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && i.OperationalStatus == OperationalStatus.Up);

            if (wifiInterface != null)
            {
                IPInterfaceProperties ipProperties = wifiInterface.GetIPProperties();
                IPAddress wifiIpAddress = ipProperties.UnicastAddresses
                    .FirstOrDefault(a => a.Address.AddressFamily == AddressFamily.InterNetwork)?.Address;

                if (wifiIpAddress != null)
                {
                    return wifiIpAddress.ToString();
                }
            }

            return null;
        }
    }
}
