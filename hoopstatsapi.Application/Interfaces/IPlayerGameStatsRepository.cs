using hoopstatsapi.Application.DTO.PlayerGameStats;
using hoopstatsapi.Domain.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Interfaces
{
    public interface IPlayerGameStatsRepository : IRepository<PlayerGameStats>
    {
        Task<PlayerGameStats> GetPlayerGameStatsByIds(int playerId, int gameId);
        Task<IEnumerable<PlayerGameStats>> GetPlayersAllGamesStats(int playerId);
    }
}
