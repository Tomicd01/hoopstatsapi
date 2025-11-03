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

        public async Task<PlayerGameStats> GetPlayerGameStatsByIds(int playerId, int gameId)
        {
            PlayerGameStats stats = (await _statsRepo.GetAsync()).FirstOrDefault(s => s.PlayerId == playerId && s.GameId == gameId);
            return stats;
        }

        public async Task UpdatePlayerGameStats(int playerId, int gameId, UpdatePlayerGameStatsDto updatePlayerGameStatsDto)
        {
            PlayerGameStats statsToUpdate = await GetPlayerGameStatsByIds(playerId, gameId);

            _mapper.Map(updatePlayerGameStatsDto, statsToUpdate);

            /*foreach(var prop in updatePlayerGameStatsDto.GetType().GetProperties())
            {
                var propValue = prop.GetValue(updatePlayerGameStatsDto);
                var propName = prop.Name;

                if(propValue != null)
                {
                    var entityProp = typeof(PlayerGameStats).GetProperty(propName);
                    if(entityProp != null && entityProp.CanWrite)
                    {
                        entityProp.SetValue(statsToUpdate, propValue);
                    }
                }
                
            }*/

            await _statsRepo.UpdateAsync(statsToUpdate);
        }
    }
}
