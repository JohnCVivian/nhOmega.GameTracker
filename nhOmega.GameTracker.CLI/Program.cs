using nhOmega.GameTracker.CLI.Endpoints;
using nhOmega.GameTracker.CLI.Model;
using nhOmega.GameTracker.CLI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using nhOmega.GameTracker.Data.SQLite;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace nhOmega.GameTracker.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {

            IHost host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var router = serviceScope.ServiceProvider.GetRequiredService<CLIRouterService>();

                ICLIEndpoint endpoint = router.Route();

                string result = await endpoint.RunAsync();

                Console.Write(result);
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) => {
                services.AddSingleton(new ArgumentsService(args));
                services.AddSingleton<CLIRouterService>();

                services.AddSqLiteDbContext();

                services.AddDataRepositories();

                // Rather than using reflection we just regester the endpoints here
                services.AddTransient<GameEndpoint>();
                services.AddTransient<DatabaseEndpoint>();
            }).ConfigureLogging(logging => {
                logging.AddFilter((provider, category, logLevel) =>
                {
                    if (provider.Contains("ConsoleLoggerProvider")
                        && category.Contains("Microsoft")
                        && logLevel >= LogLevel.Warning)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }).UseConsoleLifetime();
        }
    }
}
