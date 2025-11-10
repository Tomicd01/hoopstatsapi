using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.DTO.Seasons;
using hoopstatsapi.Domain.Entities;
using hoopstatsapi.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Interfaces
{
    public interface ISeasonService
    {
        Task<IEnumerable<Season>> GetSeasons();
        Task<Season> GetSeasonById(int id);
        Task CreateSeason(CreateSeasonDto createSeasonDto);
        Task DeleteSeason(int id);
        Task UpdateSeason(int id, UpdateSeasonDto pdateSeasonDto);
    }
}
