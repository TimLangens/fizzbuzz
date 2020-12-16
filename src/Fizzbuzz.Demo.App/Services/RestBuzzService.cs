using Fizzbuzz.Demo.App.Models;
using Fizzbuzz.Demo.App.RefitContracts;
using Refit;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public class RestBuzzService : IBuzzService
    {
        private readonly IRefitBuzzContract _buzzClient;

        public RestBuzzService()
        {
            _buzzClient = RestService.For<IRefitBuzzContract>("http://rest.buzz.localhost");
        }

        public async Task<BuzzModel> Get(int id)
        {
            var response = await _buzzClient.Get(id);
            return response.IsSuccessStatusCode
                ? response.Content
                : null;
        }
    }
}