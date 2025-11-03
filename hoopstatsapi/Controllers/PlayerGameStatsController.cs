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
    }
}
