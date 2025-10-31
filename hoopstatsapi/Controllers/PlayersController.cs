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
            try
            {
                var players = await _playerService.GetPlayers();
                if(players == null)
                {
                    return NoContent();
                }

                return Ok(players);

            }catch(Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePlayer([FromRoute] int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Id not found");
                }

                var player =  await _playerService.GetPlayerById(id);
                return Ok(player);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerDto createPlayer)
        {
            try
            {
                await _playerService.CreatePlayer(createPlayer);

                return Created(nameof(GetSinglePlayer), createPlayer);

            }catch(Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] UpdatePlayerDto updatePlayerDto)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest("Id not found");
                }

                await _playerService.UpdatePlayer(id, updatePlayerDto);

                return NoContent();

            }catch(Exception ex)
            {
                return StatusCode(500, "An Internal Error occured. Check logs.");
            }
        }


    }
}
