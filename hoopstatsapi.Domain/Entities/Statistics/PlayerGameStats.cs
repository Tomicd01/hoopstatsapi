using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Players;

namespace hoopstatsapi.Domain.Entities.Statistics
{
    public class PlayerGameStats
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }


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
