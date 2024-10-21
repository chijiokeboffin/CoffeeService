using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Config
{
    public class OpenWeatherConfig
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
