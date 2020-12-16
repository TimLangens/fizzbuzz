using Fizzbuzz.Demo.App.Models;
using Refit;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.RefitContracts
{
    public interface IRefitBuzzContract
    {
        [Get("/buzzes/{id}")]
        public Task<ApiResponse<BuzzModel>> Get(int id);
    }
}
