using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            String WebApi1Url = Environment.GetEnvironmentVariable("WebApi1Url");

            // Configure HttpClientHandler to ignore certificate validation errors.
            using var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            // Create WeatherClient.
            using var httpClient = new HttpClient(httpClientHandler);
            var weatherClient = new WeatherService.WeatherClient(WebApi1Url, httpClient);

            // Call WeatherForecast API.
            var forecast = await weatherClient.WeatherForecastAsync();
            foreach (var item in forecast)
            {
                Console.WriteLine($"{item.Date} - {item.Summary}");
            }
        }
    }
}
