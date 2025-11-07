using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities.Games;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hoopstatsapi.Host.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gameService.GetGames();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById([FromRoute] int id)
        {
            Game game = await _gameService.GetGameById(id);
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameDto createGameDto)
        {
            await _gameService.CreateGame(createGameDto);
            return Created(Request.Path.Value, createGameDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame([FromRoute] int id,[FromBody] UpdateGameDto updateGameDto)
        {
            await _gameService.UpdateGame(id, updateGameDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int id)
        {
            await _gameService.DeleteGame(id);
            return NoContent();
        }
    }
}
