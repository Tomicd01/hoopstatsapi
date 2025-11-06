using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.DTO.Game
{
    public record UpdateGameDto(DateTime? Date, int? HomeTeamId, int? AwayTeamId, string? Location, int? SeasonId);
}
