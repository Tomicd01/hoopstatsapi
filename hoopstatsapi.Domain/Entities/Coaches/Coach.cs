using hoopstatsapi.Domain.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Domain.Entities.Coaches
{
    public class Coach
    {
        public int Id { get; set; }
        public string CoachFullName { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
