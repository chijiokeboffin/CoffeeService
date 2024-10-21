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
        private readonly IOpenWeatherService _openWeatherService;
        private static int _callCount = 0;
        private const double KELVIN_TEMP = 273.15;
        public CoffeeService(IOpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        public async Task<IActionResult> BrewCoffee()
        {
            _callCount++;
           
            DateTime currentDate = DateTime.Now;

            var weatherResponse = await _openWeatherService.CallWeatherServiceAsync();
            var temperature = weatherResponse?.main.temp - KELVIN_TEMP;
            var responseMessage = temperature > 30 ? "Your refreshing iced coffee is ready" : "Your piping hot coffee is ready";

            if (currentDate.Month == 4 && currentDate.Day == 1)
            {
                return StatusCode(418, "I'm a teapot");
            }
            
            if (_callCount % 5 == 0)
            {
               return StatusCode(503, "Service Unavailable.");
            }

            var response = new ApiResponseDto {message = responseMessage, prepared = currentDate.ToString("o")};
            return Ok(response);
        }
    }
}
