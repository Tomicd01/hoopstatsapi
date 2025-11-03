using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Players;

namespace hoopstatsapi.Domain.Entities.Teams
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Points { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int PointsScored { get; set; } = 0;
        public int PointsConceded { get; set; } = 0;
        public ICollection<Game> HomeGames { get; set; } = new List<Game>();
        public ICollection<Game> AwayGames { get; set; } = new List<Game>();
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
