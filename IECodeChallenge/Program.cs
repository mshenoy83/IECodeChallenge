using IECodeChallenge.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IECodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<App>().Start();
            
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICommandParser, CommandParser>();
            serviceCollection.AddTransient<IPacmanCommandParser, PacmanCommandParser>();
            serviceCollection.AddTransient<IPacmanService, PacmanConsoleService>();
            serviceCollection.AddTransient<IPacmanService, PacmanFileParserService>();
            serviceCollection.AddTransient<IPacmanTypeStrategy,PacmanTypeStrategy>();
            serviceCollection.AddTransient<IPathFinder,PathFinder>();
            serviceCollection.AddTransient<IReportGenerator,ReportGenerator>();
            serviceCollection.AddTransient<SimulationLoader>();
            // Add app
            serviceCollection.AddTransient<App>();
        }
    }
}
