using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YotesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<YoteController> _logger;

        public YoteController(ILogger<YoteController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Create a yote
        /// </summary>
        /// <param name="createYoteDTO"></param>
        /// <returns>created yote</returns>
        [HttpPost]
        public async Task<YoteDTO> CreateYote(CreateYoteDTO createYoteDTO)
        {
            return null;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
