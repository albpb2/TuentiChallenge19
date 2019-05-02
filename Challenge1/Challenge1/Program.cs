using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Challenge1
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            try
            {
                RegisterServices();

                if (!args.Any())
                {
                    throw new ArgumentException("An input file must be specified");
                }

                var tortillasCalculator = _serviceProvider.GetService<ITortillasCalculator>();

                tortillasCalculator.CalculateTortillas(args[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                DisposeServices();
            }
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IInputParser, InputParser>();
            collection.AddScoped<IOutputWriter, OutputWriter>();
            collection.AddScoped<ITortillasCalculator, TortillasCalculator>();

            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
