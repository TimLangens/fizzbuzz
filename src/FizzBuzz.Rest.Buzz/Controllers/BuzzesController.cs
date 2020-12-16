using Fizzbuzz.Rest.Buzz.Models;
using Fizzbuzz.Rest.Buzz.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fizzbuzz.Rest.Buzz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuzzesController : ControllerBase
    {
        private readonly BuzzService _buzzService;

        public BuzzesController(BuzzService buzzService)
        {
            _buzzService = buzzService;
        }

        /// <summary>
        /// Gets all known buzzes. When no maximum is given, it only returns the first 10 known buzzes
        /// </summary>
        /// <param name="max"></param>
        /// <response code="200">A list with all known numbers</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<BuzzModel>), 200)]
        public async Task<IActionResult> GetAll(int max = 10)
        {
            var result = new List<BuzzModel>();
            await foreach(var buzz in _buzzService.GetAll(max))
            {
                result.Add(buzz);
            }
            return Ok(result);
        }

        /// <summary>
        /// Gets a known buzz.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">the known buzz</response>
        /// <response code="404">The id doesn't correspond to a known buzz</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BuzzModel), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var number = await _buzzService.Get(id);
            if (number == null)
            {
                return NotFound();
            }
            return Ok(number);
        }
    }
}
