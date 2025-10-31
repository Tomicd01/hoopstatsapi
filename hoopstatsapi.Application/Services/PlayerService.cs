using hoopstatsapi.Application.DTO.Players;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<Player> _playerRepo;
        public PlayerService(IRepository<Player> playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task DeletePlayer(int id)
        {
            await _playerRepo.DeleteAsync(id);
        }

        public Task<Player> GetPlayerById(int id)
        {
            return _playerRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _playerRepo.GetAsync();
        }

        public async Task CreatePlayer(CreatePlayerDto createPlayerDto)
        {
            Player player = new Player()
            {
                Name = createPlayerDto.Name,
                LastName = createPlayerDto.LastName,
                Age = createPlayerDto.Age,
                Position = createPlayerDto.Position,
                TeamId = createPlayerDto.TeamId
            };

            await _playerRepo.AddAsync(player);
        }

        public async Task UpdatePlayer(int playerId, UpdatePlayerDto updatePlayerDto)
        {
            Player player = await _playerRepo.GetByIdAsync(playerId);

            player.Name = updatePlayerDto.Name;
            player.LastName = updatePlayerDto.LastName;
            player.Age = (int)updatePlayerDto.Age;
            player.Position = (Domain.Enums.Position)updatePlayerDto.Position;
            player.TeamId = (int)updatePlayerDto.TeamId;

            await _playerRepo.UpdateAsync(player);
        }
    }
}
