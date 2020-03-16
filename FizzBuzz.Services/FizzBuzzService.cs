using FizzBuzz.Services.Interfaces;

namespace FizzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private const string LuckyNumber = "3";

        public string Process(int input)
        {
            if (input.ToString().Contains(LuckyNumber))
            {
                return "lucky";
            }

            if (input % 3 == 0 && input % 5 == 0)
            {
                return "fizzbuzz";
            }

            if (input % 3 == 0)
            {
                return "fizz";
            }

            if (input % 5 == 0)
            {
                return "buzz";
            }

            return input.ToString();
        }
    }
}
