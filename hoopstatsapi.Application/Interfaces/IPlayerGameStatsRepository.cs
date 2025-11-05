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
        Task<IEnumerable<hoopstatsapi.Domain.Entities.Statistics.PlayerGameStats>> GetPlayersAllGamesStats(int playerId);
    }
}
