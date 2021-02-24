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
        public async Task<ActionResult<YoteDTO>> Create([FromBody] CreateYoteDTO createYoteDTO)
        {
            var yote = await _yoteService.CreateYote(createYoteDTO);
            return CreatedAtAction(nameof(Get), new { id = yote.Id }, yote);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<YoteDTO>> Get([FromRoute] Guid id)
        {
            return Ok(await _yoteService.GetYote(id));
        } 
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<YoteDTO>>> GetAll()
        {
            return Ok(await _yoteService.GetYotes());
        }
        
        [HttpPut("{id}/actions/deactivate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<YoteDTO>>> Delete([FromRoute] Guid id)
        {
            return Ok(await _yoteService.DeleteYote(id));
        }        
        [HttpPut("{id}/actions/deactivate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<YoteDTO>>> Deactivate([FromRoute] Guid id)
        {
            return Ok(await _yoteService.DeleteYote(id));
        }
    }
}
