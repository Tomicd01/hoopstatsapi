using hoopstatsapi.Domain.Entities.Players;

namespace hoopstatsapi.Domain.Entities.Statistics
{
    public class PlayerStatsSeason
    {
        public int Id { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public int Minutes { get; set; }
        public float Eff { get; set; }
        public int FGA { get; set; }
        public int FGM { get; set; }
        public int _2PA { get; set; }
        public int _2PM { get; set; }
        public int _3PA { get; set; }
        public int _3PM { get; set; }
        public int FTA { get; set; }
        public int FTM { get; set; }
        public int ORB { get; set; }
        public int DRB { get; set; }
        public int AST { get; set; }
        public int TO { get; set; }
        public int STL { get; set; }
        public int BLK { get; set; }
        public int PFD { get; set; }
        public int PTS { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
