using System.Net.Sockets;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using ProxyService.Utils;
using eShield_API.DTOs;

namespace ProxyService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CacheReader.Set(CacheRepo.ProxyStatsCache, ConstantNames.StatsKeyName, new List<VisitedSiteDTO>());

            var host = StartupConfig.AppStartup();
            await host.StartAsync();

            // Start the proxy server
            await ProxyServer.StartProxyServerAsync();

            await host.WaitForShutdownAsync();
        }

    }
}