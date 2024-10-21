using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CoffeeService: ControllerBase, ICoffeeService
    {
       
        private static int _callCount = 0;
        public CoffeeService()
        {
           
        }

        public async Task<IActionResult> BrewCoffee()
        {
            _callCount++;
           
            DateTime currentDate = DateTime.Now;

            if (currentDate.Month == 4 && currentDate.Day == 1)
            {
                return StatusCode(418, "I'm a teapot");
            }
            
            if (_callCount % 5 == 0)
            {
               return StatusCode(503, "Service Unavailable.");
            }

            var response = new ApiResponseDto {message = "Your piping hot coffee is ready", prepared = currentDate.ToString("o")};
            return Ok(response);
        }
    }
}
