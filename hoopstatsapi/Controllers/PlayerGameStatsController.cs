using hoopstatsapi.Application.DTO.PlayerGameStats;
using hoopstatsapi.Application.DTO.Players;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hoopstatsapi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerGameStatsController : ControllerBase
    {
        private readonly IPlayerGameStatsService _statsService;

        public PlayerGameStatsController(IPlayerGameStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePlayerGameStats([FromBody] CreatePlayerGameStatsDto createPlayerGameStats)
        {
            try
            {
                await _statsService.CreatePlayerGameStats(createPlayerGameStats);

                return Created(nameof(PlayerGameStatsService), createPlayerGameStats);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePlayerGameStats([FromQuery] int playerId, [FromQuery] int gameId, UpdatePlayerGameStatsDto updatePlayerGameStatsDto)
        {
            try
            {
                if(playerId == null || gameId == null)
                {
                    return BadRequest("Id not found.");
                }

                await _statsService.UpdatePlayerGameStats(playerId, gameId, updatePlayerGameStatsDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }
    }
}
