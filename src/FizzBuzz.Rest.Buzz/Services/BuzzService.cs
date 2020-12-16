using Fizzbuzz.Rest.Buzz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fizzbuzz.Rest.Buzz.Services
{
    public class BuzzService
    {
        public async Task<BuzzModel> Get(int id)
        {
            await Task.Delay(50);
            return id % 5 == 0 ?
            new BuzzModel
            {
                Id = id,
                Word = "Buzz"
            } : null;
        }

        public async IAsyncEnumerable<BuzzModel> GetAll(int max)
        {
            var returnedBuzzes = 0;
            var nextNumber = 0;
            while(returnedBuzzes != max)
            {
                var buzz = await Get(nextNumber);
                if (buzz != null)
                {
                    yield return buzz;
                    returnedBuzzes++;
                }
                nextNumber++;
            }
        }
    }
}