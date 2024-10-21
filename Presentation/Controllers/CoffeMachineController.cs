using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoffeMachineController : ControllerBase
    {
        private IMemoryCache _cache;
        private static int _callCount = 0;
        public CoffeMachineController(IMemoryCache cache)
        {
            _cache = cache?? throw new ArgumentNullException(nameof(cache));
        }


        [HttpGet("brew-coffee")]
        public async Task<IActionResult> BrewCoffee()
        {
            DateTime currentDate = DateTime.Now;

            if (currentDate.Month == 4 && currentDate.Day == 1)
            {
                return StatusCode(418, "I'm a teapot");
            }
           
            return Ok(0);
        }

        [HttpGet("endpoint")]
        public IActionResult Endpoint()
        {
            // Increment the counter each time the endpoint is called
            _callCount++;

            return Ok($"This endpoint has been called {_callCount} times.");
        }

    }
}
