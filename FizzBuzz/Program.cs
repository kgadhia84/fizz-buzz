using System;
using System.Linq;
using FizzBuzz.Services;
using FizzBuzz.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzz
{
    public class Program
    {
        private readonly IServiceProvider _serviceProvider;

        public Program()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFizzBuzzService, FizzBuzzService>();
            serviceCollection.AddScoped<IFizzBuzzReportService, FizzBuzzReportService>();
        }

        static void Main()
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            var service = _serviceProvider.GetService<IFizzBuzzReportService>();
            var result = service.Report();

            Console.WriteLine(string.Join(" ", result.Output));
            Console.WriteLine(result.ReportOutput.Aggregate("", (key, item) => $"{key}{item.Key}: {item.Value} "));
        }
    }
}
