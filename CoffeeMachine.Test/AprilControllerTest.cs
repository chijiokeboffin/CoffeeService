using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Controllers;

namespace CoffeeMachine.Test
{
    public class AprilControllerTest
    {
        private readonly CoffeController _controller;
        private readonly ICoffeeService _service;

        public AprilControllerTest()
        {
            _service = new AprilCoffeeService();
            _controller = new CoffeController(_service);

        }

        [Fact]
        public async void BrewCoffee_WhenCalled_ReturnsStatus418ImATeapot()
        {

            ////Arrange
            int expectedStatusCode = 418;

            //// Act
            var result = await _controller.BrewCoffee() as ObjectResult;           

            // Assert
            Assert.IsType<ObjectResult>(result);
            Assert.IsType<string>(result.Value);
            Assert.Equal(expectedStatusCode, result.StatusCode);
            Assert.Equal("I'm a teapot", result.Value);
        }
        
    }
}
