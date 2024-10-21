using Contracts;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Controllers;
using Xunit;

namespace CoffeeMachine.Test
{
    public class CoffeControllerTest
    {
        private readonly CoffeController _controller;
        private readonly ICoffeeService _service;
        
        public CoffeControllerTest()
        {
            _service = new FakeCoffeeService();
            _controller = new CoffeController(_service);
           
        }

        [Fact]
        public async void BrewCoffee_WhenCalled_ReturnsOkResult()
        {
            //// Act
            var result = await _controller.BrewCoffee();             

            // Assert.
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
           
        }
        [Fact]
        public async void BrewCoffee_WhenCalled_ReturnsRightObject()
        {
            // Arrange
            var message = "Your piping hot coffee is ready";

            // Act
            var okResult = await _controller.BrewCoffee() as OkObjectResult;

            // Assert
            Assert.IsType<ApiResponseDto>(okResult.Value);
            Assert.Equal(message, (okResult.Value as ApiResponseDto).message);
        }
        [Fact]
        public async void BrewCoffee_WhenCalled_ReturnsRightDateFormat()
        {
            // Arrange
            var expected = true;
            DateTime result = new DateTime();
            string ISOFORMAT = "o";

            // Act
            var okResult = await _controller.BrewCoffee() as OkObjectResult;
            var prepared = (okResult.Value as ApiResponseDto).prepared;
            var isValidDate = DateTime.TryParseExact(prepared, ISOFORMAT, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out result);


            // Assert
            Assert.IsType<ApiResponseDto>(okResult.Value);
            Assert.Equal(expected, isValidDate);
        }       
    }
}
