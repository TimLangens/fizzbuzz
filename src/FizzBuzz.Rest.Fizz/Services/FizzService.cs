using Fizzbuzz.Rest.Fizz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fizzbuzz.Rest.Fizz.Services
{
    public class FizzService
    {
        private const int Fizz = 3;
        public async Task<FizzModel> Get(int id)
        {
            await Task.Delay(50);
            return new FizzModel
            {
                Id = id,
                Fizzable = id % Fizz == 0
            };
        }

        public async IAsyncEnumerable<FizzModel> GetAll(int max)
        {
            for(int i=1; i <= max; i++)
            {
                yield return await Get(i);
            }
        }
    }
}