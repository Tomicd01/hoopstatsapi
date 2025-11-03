using hoopstatsapi.Domain.Entities.Statistics;
using hoopstatsapi.Domain.Entities.Teams;

namespace hoopstatsapi.Domain.Entities.Games
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public string Location { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public ICollection<PlayerGameStats> PlayerStats { get; set; } = new List<PlayerGameStats>();
    }
}
