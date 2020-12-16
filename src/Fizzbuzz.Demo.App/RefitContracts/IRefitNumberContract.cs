using Fizzbuzz.Demo.App.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.RefitContracts
{
    public interface IRefitNumberContract
    {
        [Get("/numbers")]
        public Task<IEnumerable<NumberModel>> GetAllNumbers(int? max);
    }
}
