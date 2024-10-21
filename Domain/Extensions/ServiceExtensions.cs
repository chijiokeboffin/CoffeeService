using Domain.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeService, CoffeeService>();          

            return services;
        }


        public static void ConfigureAppSettingSection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenWeatherConfig>(configuration.GetSection("OpenWeatherConfig"));
        }
    }
}
