using AutoMapper;
using hoopstatsapi.Application.DTO.Teams;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepo;
        private readonly IMapper _mapper;

        public TeamService(IRepository<Team> teamRepo, IMapper mapper)
        {
            _teamRepo = teamRepo;
            _mapper = mapper;
        }
        public async Task CreateTeam(CreateTeamDto createTeamDto)
        {
            //await _coachRepo.GetByIdAsync(createTeamDto.CoachId)
            var team = _mapper.Map<Team>(createTeamDto);
            await _teamRepo.AddAsync(team);
        }

        public async Task DeleteTeam(int id)
        {
            await _teamRepo.DeleteAsync(id);
        }

        public async Task<ReturnTeamDto> GetTeamById(int id)
        {
            var team = await _teamRepo.GetByIdAsync(id);
            var returnTeam = _mapper.Map<ReturnTeamDto>(team);
            return returnTeam;
        }

        public async Task<IEnumerable<ReturnTeamDto>> GetTeams()
        {
            var allTeams = await _teamRepo.GetAsync();
            var returnAllTeams = _mapper.Map<IEnumerable<ReturnTeamDto>>(allTeams);
            return returnAllTeams;
        }

        public async Task UpdateTeam(int id, UpdateTeamDto updateTeamDto)
        {
            var team = await _teamRepo.GetByIdAsync(id);
            _mapper.Map(updateTeamDto, team);
            await _teamRepo.UpdateAsync(team);
        }
    }
}
