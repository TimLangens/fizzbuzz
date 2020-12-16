using Fizzbuzz.Demo.App.Models;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public interface IBuzzService
    {
        public Task<BuzzModel> Get(int id);
    }
}