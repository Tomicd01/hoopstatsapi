using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.DTO.Teams;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Application.Services;
using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Teams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hoopstatsapi.Host.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _teamService.GetTeams();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById([FromRoute] int id)
        {
            ReturnTeamDto team = await _teamService.GetTeamById(id);
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamDto createTeamDto)
        {
            await _teamService.CreateTeam(createTeamDto);
            return Created(Request.Path.Value, createTeamDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam([FromRoute] int id, [FromBody] UpdateTeamDto updateTeamDto)
        {
            await _teamService.UpdateTeam(id, updateTeamDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int id)
        {
            await _teamService.DeleteTeam(id);
            return NoContent();
        }
    }
}
