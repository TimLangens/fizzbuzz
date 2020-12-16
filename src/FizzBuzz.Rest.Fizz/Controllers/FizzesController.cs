using Fizzbuzz.Rest.Fizz.Models;
using Fizzbuzz.Rest.Fizz.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fizzbuzz.Rest.Fizz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzesController : ControllerBase
    {
        private readonly FizzService _fizzService;

        public FizzesController(FizzService fizzService)
        {
            _fizzService = fizzService;
        }

        /// <summary>
        /// Gets all known fizzes. When no maximum is given, it only returns the first 100 known fizzes
        /// </summary>
        /// <param name="max"></param>
        /// <response code="200">A list with all known fizzes</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<FizzModel>), 200)]
        public async Task<IActionResult> GetAll(int max = 100)
        {
            var result = new List<FizzModel>();
            await foreach (var fizz in _fizzService.GetAll(max))
            {
                result.Add(fizz);
            }
            return Ok(result);
        }

        /// <summary>
        /// Gets a known fizz.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">the known fizz</response>
        /// <response code="404">The fizz is not known</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FizzModel), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var fizz = await _fizzService.Get(id);
            if (fizz == null)
            {
                return NotFound();
            }
            return Ok(fizz);
        }
    }
}
