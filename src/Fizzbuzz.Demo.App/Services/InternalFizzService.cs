using Fizzbuzz.Demo.App.Models;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public class InternalFizzService : IFizzService
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
    }
}