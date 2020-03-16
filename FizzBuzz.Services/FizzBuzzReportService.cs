using System.Collections.Generic;
using FizzBuzz.Services.Interfaces;
using FizzBuzz.Services.Models;

namespace FizzBuzz.Services
{
    public class FizzBuzzReportService : IFizzBuzzReportService
    {
        private readonly IFizzBuzzService _fixBuzzService;
        private readonly Dictionary<string, int> _reportDictionary;

        public FizzBuzzReportService(IFizzBuzzService fixBuzzService)
        {
            _fixBuzzService = fixBuzzService;
            _reportDictionary = new Dictionary<string, int>
            {
                { "fizz", 0 },
                { "buzz", 0 },
                { "fizzbuzz", 0 },
                { "lucky", 0 },
                { "integer", 0 }
            };
        }

        public ReportModel Report()
        {
            var output = new List<string>();

            for (var i = 1; i <= 20; i++)
            {
                var result = _fixBuzzService.Process(i);
                output.Add(result);

                if (_reportDictionary.ContainsKey(result))
                {
                    _reportDictionary[result]++;
                }
                else
                {
                    _reportDictionary["integer"]++;
                }
            }

            return new ReportModel(output, _reportDictionary);
        }
    }
}
