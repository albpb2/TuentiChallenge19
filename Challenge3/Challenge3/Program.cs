using Challenge3;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Challenge2
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

                var papersUnfolder = _serviceProvider.GetService<IPapersUnfolder>();
                papersUnfolder.UnfoldPapers(args[0]);
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
            collection.AddScoped<IPapersUnfolder, PapersUnfolder>();

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
