using hoopstatsapi.Application.DTO.Players;
using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetGames();
        Task<Game> GetGameById(int id);
        Task CreateGame(CreateGameDto createGameDto);
        Task DeleteGame(int id);
        Task UpdateGame(int id, UpdateGameDto updatePlayerDto);
    }
}
