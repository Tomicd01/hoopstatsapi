using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.DTO.PlayerGameStats
{
    public record CreatePlayerGameStatsDto
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public TimeSpan? Minutes { get; set; } = new TimeSpan(0, 0, 0);
        public int? Eff { get; set; } = 0;
        public int? FGA { get; set; } = 0;
        public int? FGM { get; set; } = 0;
        public int? _2PA { get; set; } = 0;
        public int? _2PM { get; set; } = 0;
        public int? _3PA { get; set; } = 0;
        public int? _3PM { get; set; } = 0;
        public int? FTA { get; set; } = 0;
        public int? FTM { get; set; } = 0;
        public int? ORB { get; set; } = 0;
        public int? DRB { get; set; } = 0;
        public int? AST { get; set; } = 0;
        public int? TO { get; set; } = 0;
        public int? STL { get; set; } = 0;
        public int? BLK { get; set; } = 0;
        public int? PFD { get; set; } = 0;
        public int? PF { get; set; } = 0;
        public int? PTS { get; set; } = 0;
    }
}
