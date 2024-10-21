using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace CoffeeMachine.Test
{
    public class FakeCoffeeService: ControllerBase, ICoffeeService
    {
        private static int _endpointCallCount = 0;
        public async Task<IActionResult> BrewCoffee()
        {
            _endpointCallCount++;            
            DateTime currentDate = DateTime.Now;

            if (currentDate.Month == 4 && currentDate.Day == 1)
            {
                return StatusCode(418, "I'm a teapot");
            }

            if (_endpointCallCount % 5 == 0)
            {
                return StatusCode(503, "Service Unavailable.");
            }

            var response = new ApiResponseDto { message = "Your piping hot coffee is ready", prepared = currentDate.ToString("o") };
            return Ok(response);
        }   
    }
}