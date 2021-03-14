using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzz.Grpc.Numbers
{
    public class NumberService : Number.NumberBase
    {
        private List<string> unities = new List<string> { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private List<string> tens = new List<string> { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private List<string> unityTen = new List<string> { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eightteen", "nineteen" };

        public override async Task GetNumbers(NumbersRequest request, IServerStreamWriter<NumberResult> responseStream, ServerCallContext context)
        {
            for (var i = 1; i <= request.Max; i++)
            {
                await Task.Delay(100);
                if (!context.CancellationToken.IsCancellationRequested)
                {
                    await responseStream.WriteAsync(GetNumber(i));
                }
            }
        }

        private NumberResult GetNumber(int id)
        {
            return new NumberResult
            {
                Id = id,
                Word = GetWord(id),
                Binary = Convert.ToString(id, 2)
            };
        }

        private string GetWord(int id)
        {
            if (id == 100)
            {
                return "one hunderd";
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
            return word.Trim();
        }
    }
}
