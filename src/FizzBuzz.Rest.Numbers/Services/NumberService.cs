using Fizzbuzz.Rest.Numbers.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fizzbuzz.Rest.Numbers.Services
{
    public class NumberService
    {

        private List<string> unities = new List<string> { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private List<string> tens = new List<string> { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private List<string> unityTen = new List<string> { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eightteen", "nineteen" };

        public async IAsyncEnumerable<Number> GetAll(int max = 1000)
        {
            for (var i = 1; i <= max; i++)
            {
                await Task.Delay(100);
                yield return await GetNumber(i);
            }
        }

        public async Task<Number> GetNumber(int id)
        {
            return new Number
            {
                Id = id,
                Word = await GetWord(id),
                Binary = Convert.ToString(id, 2)
            };
        }

        private Task<string> GetWord(int id)
        {
            if (id == 100)
            {
                return Task.FromResult("one hunderd");
            }

            var word = string.Empty;

            if (id / 100 >= 1)
            {
                word = $"{unities[id / 100]} hunderd and ";
            }

            if ((id / 10) % 10 == 1)
            {
                word += unityTen[id % 10];
            }
            else
            {
                if ((id / 10) % 10 > 1)
                {
                    word += $"{tens[(id / 10) % 10]} ";
                }
                word += $"{unities[id % 10]}";
            }
            return Task.FromResult(word.Trim());
        }
    }
}
