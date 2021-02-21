using nhOmega.GameTracker.CLI.Endpoints;
using nhOmega.GameTracker.CLI.Model;
using nhOmega.GameTracker.CLI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace nhOmega.GameTracker.CLI
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = ConfigureServices(args);

            var router = serviceProvider.GetService<CLIRouterService>();

            ICLIEndpoint endpoint = router.Route();

            endpoint.Run();

        }

        private static ServiceProvider ConfigureServices(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton(new ArgumentsService(args));
            services.AddSingleton<CLIRouterService>();

            return services.BuildServiceProvider();
        }
    }
}
