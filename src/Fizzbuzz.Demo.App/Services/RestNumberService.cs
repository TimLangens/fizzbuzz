using Fizzbuzz.Demo.App.Models;
using Fizzbuzz.Demo.App.RefitContracts;
using Refit;
using System.Collections.Generic;

namespace Fizzbuzz.Demo.App.Services
{
    public class RestNumberService : INumberService
    {
        private readonly IRefitNumberContract _restClient;
        public RestNumberService()
        {
            _restClient = RestService.For<IRefitNumberContract>("http://rest.numbers.localhost");
        }

        public async IAsyncEnumerable<NumberModel> GetAll(int max = 1000)
        {
            var numbers = await _restClient.GetAllNumbers(max);
            foreach(var number in numbers)
            {
                yield return number;
            }
        }
    }
}