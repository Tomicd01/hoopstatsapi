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
        private readonly IPlayerGameStatsRepository _statsRepo;
        private readonly IMapper _mapper;

        public PlayerGameStatsService(IPlayerGameStatsRepository statsRepo, IMapper mapper)
        {
            _statsRepo = statsRepo;
            _mapper = mapper;
        }

        public async Task CreatePlayerGameStats(CreatePlayerGameStatsDto createPlayerGameStatsDto)
        {
            PlayerGameStats playerStats = _mapper.Map<PlayerGameStats>(createPlayerGameStatsDto);
            await _statsRepo.AddAsync(playerStats);
        }

        public async Task DeletePlayerGameStats(int playerId, int gameId)
        {
            PlayerGameStats stats = await GetPlayerGameStatsByIds(playerId, gameId);
            await _statsRepo.DeleteAsync(stats.Id);
        }

        public async Task<IEnumerable<PlayerGameStats>> GetAllPlayerStats()
        {
            return await _statsRepo.GetAsync();
        }

        public async Task<PlayerGameStats> GetPlayerGameStatsByIds(int playerId, int gameId)
        {
            PlayerGameStats stats = await _statsRepo.GetPlayerGameStatsByIds(playerId, gameId);
            return stats;
        }

        public async Task<IEnumerable<PlayerGameStats>> GetPlayersAllGamesStats(int playerId)
        {
            var allStats = await _statsRepo.GetPlayersAllGamesStats(playerId);
            return allStats;
        }

        public async Task UpdatePlayerGameStats(int playerId, int gameId, UpdatePlayerGameStatsDto updatePlayerGameStatsDto)
        {
            PlayerGameStats statsToUpdate = await GetPlayerGameStatsByIds(playerId, gameId);

            _mapper.Map(updatePlayerGameStatsDto, statsToUpdate);

            await _statsRepo.UpdateAsync(statsToUpdate);
        }
    }
}
