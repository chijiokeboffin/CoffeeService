using Contracts;
using Domain.Config;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherService
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OpenWeatherConfig _openWeatherConfig;
        public OpenWeatherService(IHttpClientFactory httpClientFactory, IOptions<OpenWeatherConfig> options)
        {
            _httpClientFactory = httpClientFactory;
            _openWeatherConfig = options.Value;
        }
        public async Task<OpenWeatherApiResponseDto?> CallWeatherServiceAsync(CancellationToken cancellationToken = default)
        {
            try
            {              

                var uri = $"/data/2.5/weather?q={_openWeatherConfig.City},{_openWeatherConfig.Country}&APPID={_openWeatherConfig.ApiKey}";

                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(_openWeatherConfig.BaseUrl);
                
                using (var response = await httpClient.GetAsync(uri))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    var responseModel = await JsonSerializer.DeserializeAsync<OpenWeatherApiResponseDto>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, cancellationToken);
                   return responseModel;
                }
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
