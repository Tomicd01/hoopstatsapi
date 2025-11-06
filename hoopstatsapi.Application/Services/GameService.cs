using AutoMapper;
using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepo;
        private readonly IMapper _mapper;

        public GameService(IRepository<Game> gameRepo, IMapper mapper)
        {
            _gameRepo = gameRepo;
            _mapper = mapper;
        }

        public async Task CreateGame(CreateGameDto createGameDto)
        {
            Game game = _mapper.Map<Game>(createGameDto);
            await _gameRepo.AddAsync(game);
        }

        public async Task DeleteGame(int id)
        {
            await _gameRepo.DeleteAsync(id);
        }

        public async Task<Game> GetGameById(int id)
        {
            Game game = await _gameRepo.GetByIdAsync(id);
            return game;
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            return await _gameRepo.GetAsync();
        }

        public async Task UpdateGame(int id, UpdateGameDto updateGameDto)
        {
            Game game = await _gameRepo.GetByIdAsync(id);
            Game updatedGame = _mapper.Map<Game>(updateGameDto);
            await _gameRepo.UpdateAsync(updatedGame);
        }
    }
}
