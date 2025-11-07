using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoopstatsapi.Application.DTO.PlayerGameStats;
using AutoMapper;
using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Players;

namespace hoopstatsapi.Application.Services
{
    public class PlayerGameStatsService : IPlayerGameStatsService
    {
        private readonly IPlayerGameStatsRepository _statsRepo;
        private readonly IRepository<Game> _gameRepo;
        private readonly IRepository<Player> _playerRepo;
        private readonly IMapper _mapper;

        public PlayerGameStatsService(IPlayerGameStatsRepository statsRepo,
            IRepository<Game> gameRepo,
            IRepository<Player> playerRepo,
            IMapper mapper)
        {
            _statsRepo = statsRepo;
            _gameRepo = gameRepo;
            _playerRepo = playerRepo;
            _mapper = mapper;
        }

        public async Task CreatePlayerGameStats(CreatePlayerGameStatsDto createPlayerGameStatsDto)
        {
            var game = await _gameRepo.GetByIdAsync(createPlayerGameStatsDto.GameId);
            var player = await _playerRepo.GetByIdAsync(createPlayerGameStatsDto.PlayerId);
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

        public async Task<IEnumerable<ReturnPlayerGameStatsDto>> GetPlayersAllGamesStats(int playerId)
        {
            var allStats = await _statsRepo.GetPlayersAllGamesStats(playerId);

            var statsDto = _mapper.Map<IEnumerable<ReturnPlayerGameStatsDto>>(allStats);
            return statsDto;
        }

        public async Task UpdatePlayerGameStats(int playerId, int gameId, UpdatePlayerGameStatsDto updatePlayerGameStatsDto)
        {
            PlayerGameStats statsToUpdate = await GetPlayerGameStatsByIds(playerId, gameId);

            _mapper.Map(updatePlayerGameStatsDto, statsToUpdate);

            await _statsRepo.UpdateAsync(statsToUpdate);
        }
    }
}
