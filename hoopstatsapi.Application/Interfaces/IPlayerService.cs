using hoopstatsapi.Application.DTO.Players;
using hoopstatsapi.Domain.Entities.Players;

namespace hoopstatsapi.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayerById(int id);
        Task CreatePlayer(CreatePlayerDto createPlayerDto);
        Task DeletePlayer(int id);
        Task UpdatePlayer(int playerId, UpdatePlayerDto updatePlayerDto);
    }
}
