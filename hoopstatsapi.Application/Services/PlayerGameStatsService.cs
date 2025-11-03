using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoopstatsapi.Application.DTO.PlayerGameStats;
using AutoMapper;

namespace hoopstatsapi.Application.Services
{
    public class PlayerGameStatsService : IPlayerGameStatsService
    {
        private readonly IRepository<PlayerGameStats> _statsRepo;
        private readonly IMapper _mapper;

        public PlayerGameStatsService(IRepository<PlayerGameStats> statsRepo, IMapper mapper)
        {
            _statsRepo = statsRepo;
            _mapper = mapper;
        }

        public async Task CreatePlayerGameStats(CreatePlayerGameStatsDto createPlayerGameStatsDto)
        {
            PlayerGameStats playerStats = _mapper.Map<PlayerGameStats>(createPlayerGameStatsDto);
            await _statsRepo.AddAsync(playerStats);
        }

        public Task DeletePlayerGameStats(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlayerGameStats>> GetAllPlayerStats()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerGameStats> GetPlayerGameStatsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlayerGameStats(int playerId, int gameId, UpdatePlayerGameStatsDto updatePlayerDto)
        {
            throw new NotImplementedException();
        }
    }
}
