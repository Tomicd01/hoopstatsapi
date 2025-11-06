using AutoMapper;
using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.DTO.PlayerGameStats;
using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePlayerGameStatsDto, PlayerGameStats>();
            CreateMap<UpdatePlayerGameStatsDto, PlayerGameStats>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CreateGameDto, Game>();
            CreateMap<UpdateGameDto, Game>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
