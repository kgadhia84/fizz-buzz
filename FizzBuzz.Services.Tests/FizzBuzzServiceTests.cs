using System.Collections.Generic;
using FizzBuzz.Services.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Services.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private IFizzBuzzService fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            fizzBuzzService = new FizzBuzzService();
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void Process_Returns_Expected_Result(int value, string expectedResult)
        {
            var result = fizzBuzzService.Process(value);
            result.Should().Be(expectedResult);
        }

        private static IEnumerable<object[]> TestCases()
        {
            yield return new object[] { 1, "1" };
            yield return new object[] { 2, "2" };
            yield return new object[] { 3, "lucky" };
            yield return new object[] { 4, "4" };
            yield return new object[] { 5, "buzz" };
            yield return new object[] { 6, "fizz" };
            yield return new object[] { 7, "7" };
            yield return new object[] { 8, "8" };
            yield return new object[] { 9, "fizz" };
            yield return new object[] { 10, "buzz" };
            yield return new object[] { 11, "11" };
            yield return new object[] { 12, "fizz" };
            yield return new object[] { 13, "lucky" };
            yield return new object[] { 14, "14" };
            yield return new object[] { 15, "fizzbuzz" };
            yield return new object[] { 16, "16" };
            yield return new object[] { 17, "17" };
            yield return new object[] { 18, "fizz" };
            yield return new object[] { 19, "19" };
            yield return new object[] { 20, "buzz" };
        }
    }
}
