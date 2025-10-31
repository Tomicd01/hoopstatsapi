using hoopstatsapi.Domain.Enums;

namespace hoopstatsapi.Application.DTO.Players
{
    public record CreatePlayerDto(string Name, string LastName, int Age, Position Position, int TeamId);
}
