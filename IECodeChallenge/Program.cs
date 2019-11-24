using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using IECodeChallenge.Services;

using Microsoft.Extensions.DependencyInjection;

namespace IECodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //while (true)
            //{
            //    var input = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(input) && input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        break;
            //    }
            //    Console.WriteLine("Accepted");
            //}

            //Console.Write("Ok bye");
            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<App>().Start();
            
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
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
