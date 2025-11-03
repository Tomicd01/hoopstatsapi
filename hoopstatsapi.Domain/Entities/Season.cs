using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Statistics;

namespace hoopstatsapi.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string SeasonName { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
