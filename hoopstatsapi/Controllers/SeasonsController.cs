using hoopstatsapi.Application.DTO.Seasons;
using hoopstatsapi.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hoopstatsapi.Host.Controllers
{
    [Route("api/seasons")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly ISeasonService _seasonService;

        public SeasonsController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeasons()
        {
            var seasons = await _seasonService.GetSeasons();
            return Ok(seasons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeasonById([FromRoute] int id)
        {
            var season = await _seasonService.GetSeasonById(id);
            return Ok(season);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason([FromBody] CreateSeasonDto createSeasonDto)
        {
            await _seasonService.CreateSeason(createSeasonDto);
            return Created(Request.Path.Value, createSeasonDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeason([FromRoute] int id,[FromBody] UpdateSeasonDto updateSeasonDto)
        {
            await _seasonService.UpdateSeason(id, updateSeasonDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGame([FromRoute] int id)
        {
            await _seasonService.DeleteSeason(id);
            return NoContent();
        }
    }
}
