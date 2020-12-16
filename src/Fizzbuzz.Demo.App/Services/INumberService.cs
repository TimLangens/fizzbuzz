using Fizzbuzz.Demo.App.Models;
using System.Collections.Generic;

namespace Fizzbuzz.Demo.App.Services
{
    public interface INumberService
    {
        public IAsyncEnumerable<NumberModel> GetAll(int max = 1000);
    }
}