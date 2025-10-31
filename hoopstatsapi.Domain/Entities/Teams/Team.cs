using hoopstatsapi.Domain.Entities.Players;

namespace hoopstatsapi.Domain.Entities.Teams
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
