using hoopstatsapi.Domain.Enums;
using hoopstatsapi.Domain.Entities.Statistics;
using hoopstatsapi.Domain.Entities.Teams;

namespace hoopstatsapi.Domain.Entities.Players
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Position Position { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<PlayerGameStats> GameStats { get; set; } = new List<PlayerGameStats>();

    }
}
