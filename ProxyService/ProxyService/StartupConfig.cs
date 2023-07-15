using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxyService.Services;
using Serilog;

namespace ProxyService
{
    internal class StartupConfig
    {
        static void BuildConfig(IConfigurationBuilder builder)
        {
            // Check the current directory that the application is running on 
            // Then once the file 'appsetting.json' is found, we are adding it.
            // We add env variables, which can override the configs in appsettings.json
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
        public static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder() // Initialising the Host 
                        .ConfigureServices((context, services) => { // Adding the DI container for configuration
                            services.AddHttpClient<HttpClientService>();
                            services.AddHostedService<UsageStatsBackgroundService>();
                        })
                        .UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)) // Add Serilog
                        .Build(); // Build the Host

            return host;
        }
    }
}
