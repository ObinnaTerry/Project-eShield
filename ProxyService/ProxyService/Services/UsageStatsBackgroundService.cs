using eShield_API.DTOs;
using Microsoft.Extensions.Hosting;
using ProxyService.Utils;
using Serilog;
using System.Text;
using System.Text.Json;

namespace ProxyService.Services
{
    internal class UsageStatsBackgroundService : IHostedService, IDisposable
    {
        private static readonly ILogger _logger = Log.ForContext<UsageStatsBackgroundService>();
        private readonly HttpClientService _httpClient;
        private Timer? _timer = null;

        public UsageStatsBackgroundService(HttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Background Service is running");

            List<VisitedSiteDTO> visitedSites = CacheReader.Update(CacheRepo.ProxyStatsCache, ConstantNames.StatsKeyName, null, true);

            _timer = new Timer(UploadStats, visitedSites, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void UploadStats(object? state)
        {
            var client = _httpClient.Client;
            List<VisitedSiteDTO> visitedSites = (List<VisitedSiteDTO>)state!;
            var httpRequestContent = new StringContent(JsonSerializer.Serialize(visitedSites), Encoding.UTF8);

            _logger.Information("Simulating API call");
            _logger.Information(visitedSites.Count.ToString());

            using (HttpResponseMessage response = await client.PostAsync(client.BaseAddress, httpRequestContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    _logger.Information($"Successfully transmitted stats to the App Service");
                }

                else
                {
                    _logger.Error($"Failed to upload proxy stats to App Service. Error status {response.StatusCode}");
                    foreach (VisitedSiteDTO item in (List<VisitedSiteDTO>)state)
                    {
                        CacheReader.Update(CacheRepo.ProxyStatsCache, ConstantNames.StatsKeyName, item);

                    }
                }
            }
        }
    }
}
