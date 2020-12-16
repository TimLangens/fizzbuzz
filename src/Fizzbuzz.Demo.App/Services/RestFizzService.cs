using Fizzbuzz.Demo.App.Models;
using Fizzbuzz.Demo.App.RefitContracts;
using Refit;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public class RestFizzService : IFizzService
    {
        private readonly IRefitFizzContract _fizzClient;

        public RestFizzService()
        {
            _fizzClient = RestService.For<IRefitFizzContract>("http://rest.fizz.localhost");
        }

        public async Task<FizzModel> Get(int id)
        {
            return await _fizzClient.Get(id);
        }
    }
}