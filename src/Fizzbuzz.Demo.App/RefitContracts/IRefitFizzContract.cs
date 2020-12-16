using Fizzbuzz.Demo.App.Models;
using Refit;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.RefitContracts
{
    public interface IRefitFizzContract
    {
        [Get("/fizzes/{id}")]
        public Task<FizzModel> Get(int id);
    }
}
