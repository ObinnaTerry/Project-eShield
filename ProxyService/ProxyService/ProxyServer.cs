using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Serilog;

namespace ProxyService
{
    internal class ProxyServer
    {
        private static readonly ILogger _logger = Log.ForContext<ProxyServer>();

        public static async Task StartProxyServerAsync()
        {
            // Create a TCP listener on the desired proxy port
            int proxyPort = 8080;
            TcpListener listener = new TcpListener(IPAddress.Any, proxyPort);
            listener.Start();
            _logger.Information($"Proxy server started on port {proxyPort}");

            try
            {
                while (true)
                {
                    // Accept incoming client connections asynchronously
                    TcpClient client = await listener.AcceptTcpClientAsync();


                    // Handle each client connection concurrently
                    Task.Run(() => HandleClientAsync(client));
                }
            }
            finally
            {
                listener.Stop();
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            using (client)
            {
                try
                {
                    string clientIpAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                    _logger.Information(clientIpAddress);

                    // Read the client's request
                    NetworkStream clientStream = client.GetStream();
                    byte[] buffer = new byte[4096];
                    int bytesRead = await clientStream.ReadAsync(buffer, 0, buffer.Length);
                    string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Process the request and generate the response

                    // Forward the request to the target server
                    using (TcpClient targetClient = new TcpClient("targetserver.com", 80))
                    {
                        NetworkStream targetStream = targetClient.GetStream();

                        // Send the request to the target server
                        await targetStream.WriteAsync(buffer, 0, bytesRead);

                        // Read the response from the target server
                        bytesRead = await targetStream.ReadAsync(buffer, 0, buffer.Length);

                        // Forward the response to the client
                        await clientStream.WriteAsync(buffer, 0, bytesRead);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during the proxying process
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
