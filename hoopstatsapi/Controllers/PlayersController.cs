using hoopstatsapi.Infrastructure.Data;
using hoopstatsapi.Application.DTO.Players;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using hoopstatsapi.Application.Services;
using hoopstatsapi.Application.Interfaces;

namespace hoopstatsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetPlayers();
            if(players == null)
            {
                return NoContent();
            }

            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePlayer([FromRoute] int id)
        { 
            var player =  await _playerService.GetPlayerById(id);
            return Ok(player);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerDto createPlayer)
        {
            await _playerService.CreatePlayer(createPlayer);
            return Created(nameof(GetSinglePlayer), createPlayer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer([FromRoute] int id, [FromBody] UpdatePlayerDto updatePlayerDto)
        {

            await _playerService.UpdatePlayer(id, updatePlayerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            await _playerService.DeletePlayer(id);
            return NoContent();
        }

    }
}
