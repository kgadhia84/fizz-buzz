using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FizzBuzz.Services.Interfaces;
using FizzBuzz.Services.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Services.Tests
{
    [TestFixture]
    public class FizzBuzzReportServiceTests
    {
        private IFizzBuzzReportService reportService;
        private Mock<IFizzBuzzService> fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            fizzBuzzService = new Mock<IFizzBuzzService>();
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 1))).Returns("1");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 2))).Returns("2");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 3))).Returns("lucky");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 4))).Returns("4");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 5))).Returns("buzz");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 6))).Returns("fizz");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 7))).Returns("7");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 8))).Returns("8");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 9))).Returns("fizz");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 10))).Returns("buzz");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 11))).Returns("11");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 12))).Returns("fizz");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 13))).Returns("lucky");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 14))).Returns("14");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 15))).Returns("fizzbuzz");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 16))).Returns("16");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 17))).Returns("17");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 18))).Returns("fizz");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 19))).Returns("19");
            fizzBuzzService.Setup(x => x.Process(It.Is<int>(i => i == 20))).Returns("buzz");

            reportService = new FizzBuzzReportService(fizzBuzzService.Object);
        }

        [Test]
        public void Report_ReturnsExpectedResults()
        {
            var result = reportService.Report();

            var outputList = new List<string>
            {
                "1", "2", "lucky", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "lucky", "14", "fizzbuzz", "16", "17", "fizz", "19", "buzz"
            };

            var reportList = new Dictionary<string, int>
            {
                { "fizz", 4 },
                { "buzz", 3 },
                { "fizzbuzz", 1 },
                { "lucky", 2 },
                { "integer", 10 }
            };

            result.Should().BeEquivalentTo(new ReportModel(outputList, reportList));
        }
    }
}
