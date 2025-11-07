using hoopstatsapi.Application.DTO.PlayerGameStats;
using hoopstatsapi.Application.DTO.Players;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Application.Services;
using hoopstatsapi.Domain.Entities.Games;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hoopstatsapi.Host.Controllers
{
    [Route("api/stats")]
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
            var stats = await _statsService.GetAllPlayerStats();
            return Ok(stats);
        }

        [HttpGet("{playerId}/{gameId}")]
        public async Task<IActionResult> GetPlayerGameStatsByIds([FromRoute] int playerId, [FromRoute] int gameId)
        {
            var stats = await _statsService.GetPlayerGameStatsByIds(playerId, gameId);
            return Ok(stats);
        }

        [HttpGet("singleplayerstats/{playerId}")]
        public async Task<IActionResult> GetPlayersAllGamesStats([FromRoute] int playerId)
        {
            var stats = await _statsService.GetPlayersAllGamesStats(playerId);
            return Ok(stats);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerGameStats([FromBody] CreatePlayerGameStatsDto createPlayerGameStats)
        {
             await _statsService.CreatePlayerGameStats(createPlayerGameStats);
             return Created(nameof(PlayerGameStatsService), createPlayerGameStats);
        }

        [HttpPut("{playerId}/{gameId}")]
        public async Task<IActionResult> UpdatePlayerGameStats([FromRoute] int playerId, [FromRoute] int gameId, UpdatePlayerGameStatsDto updatePlayerGameStatsDto)
        {
            await _statsService.UpdatePlayerGameStats(playerId, gameId, updatePlayerGameStatsDto);
            return NoContent();
        }
    }
}
