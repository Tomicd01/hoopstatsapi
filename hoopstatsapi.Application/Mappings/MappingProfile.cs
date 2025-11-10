using AutoMapper;
using hoopstatsapi.Application.DTO.Game;
using hoopstatsapi.Application.DTO.PlayerGameStats;
using hoopstatsapi.Application.DTO.Seasons;
using hoopstatsapi.Application.DTO.Teams;
using hoopstatsapi.Domain.Entities;
using hoopstatsapi.Domain.Entities.Games;
using hoopstatsapi.Domain.Entities.Statistics;
using hoopstatsapi.Domain.Entities.Teams;
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
            CreateMap<PlayerGameStats, ReturnPlayerGameStatsDto>()
                .ForMember(dest => dest.PlayerName,
                           opt => opt.MapFrom(src => src.Player.Name + " " + src.Player.LastName));
            CreateMap<CreateTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();
            CreateMap<Team, ReturnTeamDto>()
                .ForMember(dest => dest.CoachName,
                           opt => opt.MapFrom(src => src.Coach.CoachFullName));
            CreateMap<CreateSeasonDto, Season>();
            CreateMap<UpdateSeasonDto, Season>();
        }
    }
}
