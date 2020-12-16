using Fizzbuzz.Demo.App.Models;
using System.Threading.Tasks;

namespace Fizzbuzz.Demo.App.Services
{
    public interface IFizzService
    {
        public Task<FizzModel> Get(int id);
    }

}
