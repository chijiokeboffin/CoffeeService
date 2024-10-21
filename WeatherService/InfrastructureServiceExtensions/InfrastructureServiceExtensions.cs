using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.InfrastructureServiceExtensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection ConfigureInfrastructureServiceExtensions(this IServiceCollection services)
        {            
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();

            return services;
        }
    }
}
