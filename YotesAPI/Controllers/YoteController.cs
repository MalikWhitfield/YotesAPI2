using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IYoteService _yoteService;
        public YoteController(ILogger<YoteController> logger, IYoteService yoteService)
        {
            _logger = logger;
            _yoteService = yoteService;
        }
        /// <summary>
        /// Create a yote
        /// </summary>
        /// <param name="createYoteDTO"></param>
        /// <returns>created yote</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<YoteDTO>> CreateYote(CreateYoteDTO createYoteDTO)
        {
            var yote = await _yoteService.CreateYote(createYoteDTO);
            return CreatedAtAction(nameof(Get), new { id = yote.Id }, yote);
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
