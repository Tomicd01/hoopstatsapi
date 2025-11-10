using AutoMapper;
using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.DTO.Seasons;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Domain.Entities;
using hoopstatsapi.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly IRepository<Season> _seasonRepo;
        private readonly IMapper _mapper;
        public SeasonService(IRepository<Season> seasonRepo, IMapper mapper)
        {
            _seasonRepo = seasonRepo;
            _mapper = mapper;
        }

        public async Task CreateSeason(CreateSeasonDto createSeasonDto)
        {
            var season = _mapper.Map<Season>(createSeasonDto);
            await _seasonRepo.AddAsync(season);
        }

        public async Task DeleteSeason(int id)
        {
            await _seasonRepo.DeleteAsync(id);
        }

        public async Task<Season> GetSeasonById(int id)
        {
            var season = await _seasonRepo.GetByIdAsync(id);
            return season;
        }

        public async Task<IEnumerable<Season>> GetSeasons()
        {
            return await _seasonRepo.GetAsync();
        }

        public async Task UpdateSeason(int id, UpdateSeasonDto updateSeasonDto)
        {
            var season = await _seasonRepo.GetByIdAsync(id);
            _mapper.Map(updateSeasonDto, season);
            await _seasonRepo.UpdateAsync(season);
        }
    }
}
