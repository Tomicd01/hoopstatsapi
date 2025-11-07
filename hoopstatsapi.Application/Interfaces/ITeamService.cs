using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.DTO.Teams;
using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<ReturnTeamDto>> GetTeams();
        Task<ReturnTeamDto> GetTeamById(int id);
        Task CreateTeam(CreateTeamDto createTeamDto);
        Task DeleteTeam(int id);
        Task UpdateTeam(int id, UpdateTeamDto updateTeamDto);
    }
}
