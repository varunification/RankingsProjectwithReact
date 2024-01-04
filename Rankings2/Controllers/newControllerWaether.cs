using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rankings2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class newWeatherController :ControllerBase


    {
        private readonly ILogger<newWeatherController> _logger;

        public newWeatherController(ILogger<newWeatherController> logger)
        {
                _logger = logger;
        }


        public enum WeatherSummary
        {
            Freezing,
            Bracing,
            Chilly,
            Cool,
            Mild,
            Warm,
            Balmy,
            Hot,
            Sweltering,
            Scorching
        }

        List<string> WeatherSummaryArray = new List<string> {"Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching" };

        public class WeatherForecast
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
        }
        
        private static readonly WeatherSummary[] Summaries = Enum.GetValues(typeof(WeatherSummary))
                                                           .Cast<WeatherSummary>()
                                                           .ToArray();
        [HttpGet]
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            var rng = new Random();
            Response.Headers.Add("Custom-Header", "Hello from the server!");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = WeatherSummaryArray[(int)Summaries[rng.Next(Summaries.Length)]]
            });
        }


    }
}
