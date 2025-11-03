using hoopstatsapi.Application.DTO.PlayerGameStats;
using hoopstatsapi.Application.DTO.Players;
using hoopstatsapi.Domain.Entities.Players;
using hoopstatsapi.Domain.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Interfaces
{
    public interface IPlayerGameStatsService
    {
        Task<IEnumerable<PlayerGameStats>> GetAllPlayerStats();
        Task<PlayerGameStats> GetPlayerGameStatsByIds(int playerId, int gameId);
        Task CreatePlayerGameStats(CreatePlayerGameStatsDto createPlayerGameStatsDto);
        Task DeletePlayerGameStats(int id);
        Task UpdatePlayerGameStats(int playerId, int gameId, UpdatePlayerGameStatsDto updatePlayerDto);
    }
}
