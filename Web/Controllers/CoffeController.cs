using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoffeController : ControllerBase
    {        
        private readonly ICoffeeService _coffeeService;
        public CoffeController(ICoffeeService coffeeService)
        {           
            _coffeeService = coffeeService ?? throw new ArgumentNullException(nameof(coffeeService));
        }


        [HttpGet("brew-coffee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status418ImATeapot)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> BrewCoffee()
        {            
            return await _coffeeService.BrewCoffee();
        }       

    }
}
