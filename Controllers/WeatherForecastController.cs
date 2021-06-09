using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ms_mvc_options.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Settings Settings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsSnapshot<Settings> settings)
        {
            _logger = logger;
            Settings = settings.Value;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var items = Settings.Summaries.Items;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = items[rng.Next(items.Length)]
            })
            .ToArray();
        }
    }
}
