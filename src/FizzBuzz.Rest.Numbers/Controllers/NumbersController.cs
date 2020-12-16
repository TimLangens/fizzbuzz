using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Fizzbuzz.Rest.Numbers.Services;
using System.Collections.Generic;
using Fizzbuzz.Rest.Numbers.Model;

namespace Fizzbuzz.Rest.Numbers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly NumberService _numberService;

        public NumbersController(NumberService numberService)
        {
            _numberService = numberService;
        }

        /// <summary>
        /// Gets all known numbers. When no maximum is given, it only returns the first 100 known numbers
        /// </summary>
        /// <param name="max"></param>
        /// <response code="200">A list with all known numbers</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Number>), 200)]
        public async Task<IActionResult> GetAll(int max = 100)
        {
            var list = new List<Number>();
            await foreach (var number in _numberService.GetAll(max))
            {
                await Task.Delay(100);
                list.Add(number);
            }
            return Ok(list);
        }

        /// <summary>
        /// Gets a known numbers.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">A list with all known numbers</response>
        /// <response code="404">The number is not known</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var number = await _numberService.GetNumber(id);
            if (number == null)
            {
                return NotFound();
            }
            return Ok(number);
        }
    }
}
