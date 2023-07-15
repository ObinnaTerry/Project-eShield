using System.Net.Sockets;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ProxyService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = StartupConfig.AppStartup();
            await host.StartAsync();

            // Start the proxy server
            await ProxyServer.StartProxyServerAsync();

            await host.WaitForShutdownAsync();
        }

    }
}