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
        public static void ConfigureServicesExtensions(this IServiceCollection services)
        {              
            services.AddScoped<ICoffeeService, CoffeeService>();
        }
    }
}
