using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.DTO.Teams
{
    public record UpdateTeamDto
    {
        public string? TeamName { get; init; }
        public int? Points { get; init; }
        public int? Wins { get; init; }
        public int? Losses { get; init; }
        public int? PointsScored { get; init; }
        public int? PointsConceded { get; init; }
        public int? CoachId { get; init; }
    }
}
