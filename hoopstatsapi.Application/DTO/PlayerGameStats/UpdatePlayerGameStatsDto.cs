using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.DTO.PlayerGameStats
{
    public record UpdatePlayerGameStatsDto
    {
        public TimeSpan? Minutes { get; set; }
        public int? Eff { get; set; }
        public int? FGA { get; set; } 
        public int? FGM { get; set; } 
        public int? _2PA { get; set; }
        public int? _2PM { get; set; } 
        public int? _3PA { get; set; } 
        public int? _3PM { get; set; } 
        public int? FTA { get; set; } 
        public int? FTM { get; set; } 
        public int? ORB { get; set; }
        public int? DRB { get; set; } 
        public int? AST { get; set; } 
        public int? TO { get; set; } 
        public int? STL { get; set; } 
        public int? BLK { get; set; } 
        public int? PFD { get; set; } 
        public int? PF { get; set; } 
        public int? PTS { get; set; } 
    }
}
