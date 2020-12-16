using Fizzbuzz.Demo.App.Models;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public class InternalBuzzService: IBuzzService
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
    }
}