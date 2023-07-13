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

            //int proxyPort = 8080;
            //string proxyUrl = $"http://{wifiIpAddress}:{proxyPort}/";
            //string proxyHttpsUrl = $"https://{wifiIpAddress}:{443}/";
            //HttpListener listener = new HttpListener();
            //listener.Prefixes.Add(proxyUrl);
            //listener.Prefixes.Add(proxyHttpsUrl);
            //listener.Start();
            //_logger.Information($"Proxy server started on {proxyUrl}");

            //Create an HTTP listener on the desired proxy port
            int proxyPort = 8080;
            string proxyUrl = $"https://*:{proxyPort}/";
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(proxyUrl);
            listener.Start();
            _logger.Information($"Proxy server started on {proxyUrl}");

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
                _logger.Information($"Received request from {clientIpAddress}");

                WebHeaderCollection headers = (WebHeaderCollection)context.Request.Headers;

                string userAgent = headers["User-Agent"];
                string contentType = headers["Content-Type"];

                string destinationUrl = context.Request.Url.ToString();

                // Extract the destination host and port from the request URL
                Uri requestUri = new Uri(destinationUrl);
                string destinationHost = requestUri.Host;
                string scheme = requestUri.Scheme;
                int destinationPort =  scheme == "http" ? 80 : 443;
                string httpMethod = context.Request.HttpMethod;

                using (StreamReader reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                {
                    string request = await reader.ReadToEndAsync();

                    // Create HttpClient instance
                    using (HttpClient httpClient = new HttpClient())
                    {
                        // Construct the target URL with the extracted destination host and port
                        string targetUrl = destinationPort != -1 ? $"{requestUri.Scheme}://{destinationHost}:{destinationPort}{requestUri.PathAndQuery}" :
                                                $"{requestUri.Scheme}://{destinationHost}{requestUri.PathAndQuery}";

                        HttpResponseMessage response;
                        if (httpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase))
                        {
                            response = await httpClient.GetAsync(targetUrl);
                        }
                        else if (httpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                        {
                            response = await httpClient.PostAsync(targetUrl, new StringContent(request));
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                            return;
                        }

                        byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

                        context.Response.ContentLength64 = responseBytes.Length;
                        await context.Response.OutputStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
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
            string hostName = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

            IPAddress wifiIpAddress = hostEntry.AddressList.FirstOrDefault(
                address => address.AddressFamily == AddressFamily.InterNetwork);

            if (wifiIpAddress != null)
            {
                return wifiIpAddress.ToString();
            }

            return null;
        }

        //private static string? GetWifiIpAddress()
        //{
        //    NetworkInterface wifiInterface = NetworkInterface.GetAllNetworkInterfaces()
        //        .FirstOrDefault(i => i.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && i.OperationalStatus == OperationalStatus.Up);

        //    if (wifiInterface != null)
        //    {
        //        IPInterfaceProperties ipProperties = wifiInterface.GetIPProperties();
        //        IPAddress wifiIpAddress = ipProperties.UnicastAddresses
        //            .FirstOrDefault(a => a.Address.AddressFamily == AddressFamily.InterNetwork)?.Address;

        //        if (wifiIpAddress != null)
        //        {
        //            return wifiIpAddress.ToString();
        //        }
        //    }

        //    return null;
        //}
    }
}
