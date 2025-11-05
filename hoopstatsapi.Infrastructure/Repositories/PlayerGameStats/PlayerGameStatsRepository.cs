using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities.Statistics;
using hoopstatsapi.Infrastructure.Data;
using hoopstatsapi.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Infrastructure.Repositories.PlayerGameStats
{
    public class PlayerGameStatsRepository : Repository<hoopstatsapi.Domain.Entities.Statistics.PlayerGameStats>, IPlayerGameStatsRepository
    {

        public PlayerGameStatsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<hoopstatsapi.Domain.Entities.Statistics.PlayerGameStats> GetPlayerGameStatsByIds(int playerId, int gameId)
        {
            var stat = await _context.PlayerGameStats.FirstOrDefaultAsync(s => s.PlayerId == playerId && s.GameId == gameId);
            return stat;
        }

        public async Task<IEnumerable<hoopstatsapi.Domain.Entities.Statistics.PlayerGameStats>> GetPlayersAllGamesStats(int playerId)
        {
            var stats = await _context.PlayerGameStats.Where(s => s.PlayerId == playerId).ToListAsync();
            return stats;
        }

    }
}
