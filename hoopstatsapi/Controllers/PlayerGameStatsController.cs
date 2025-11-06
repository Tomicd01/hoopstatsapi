using hoopstatsapi.Application.DTO.PlayerGameStats;
using hoopstatsapi.Application.DTO.Players;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Application.Services;
using hoopstatsapi.Domain.Entities.Games;
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

        [HttpGet]
        public async Task<IActionResult> GetAllPlayersGameStats()
        {
            try
            {
                var stats = await _statsService.GetAllPlayerStats();

                if (stats == null)
                {
                    return NoContent();
                }

                return Ok(stats);

            }catch(Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }

        [HttpGet("singlestat")]
        public async Task<IActionResult> GetPlayerGameStatsByIds([FromQuery] int playerId, [FromQuery] int gameId)
        {
            try
            {
                var stats = await _statsService.GetPlayerGameStatsByIds(playerId, gameId);

                if (stats == null)
                {
                    return Ok("No records for specified player and game were found");
                }

                return Ok(stats);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }

        [HttpGet("singleplayerstats/{playerId}")]
        public async Task<IActionResult> GetPlayersAllGamesStats([FromRoute] int playerId)
        {
            try
            {
                var stats = await _statsService.GetPlayersAllGamesStats(playerId);

                if (stats == null)
                {
                    return Ok("No records for specified player were found");
                }

                return Ok(stats);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }

        [HttpPost]
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

        [HttpPut("{playerId}/{gameId}")]
        public async Task<IActionResult> UpdatePlayerGameStats([FromRoute] int playerId, [FromRoute] int gameId, UpdatePlayerGameStatsDto updatePlayerGameStatsDto)
        {
            try
            {
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
