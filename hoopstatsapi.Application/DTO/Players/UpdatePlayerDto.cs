using hoopstatsapi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.DTO.Players
{
    public record UpdatePlayerDto(string? Name, string? LastName, int? Age, Position? Position, int? TeamId);
}
