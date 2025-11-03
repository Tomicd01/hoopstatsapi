using hoopstatsapi.Domain.Entities.Statistics;

namespace hoopstatsapi.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string SeasonName { get; set; }
        public ICollection<PlayerStatsSeason> PlayerStatsSeasons { get; set; } = new List<PlayerStatsSeason>();
    }
}
