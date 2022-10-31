using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.GameAward;

namespace GameCritic.Application.Profiles
{
    public class GameAwardProfile : Profile
    {
        public GameAwardProfile()
        {
            CreateMap<GameAward, GameAwardListDto>()
                .ForMember(ga => ga.Award, c => c.MapFrom(a => a.Award));
            CreateMap<CreateGameAwardDto, GameAward>()
                .ForMember(ga => ga.AwardId, c => c.MapFrom(a => a.AwardId));
            CreateMap<GameAward, AwardGameListDto>()
                .ForMember(ga => ga.Game, c => c.MapFrom(g => g.Game));
        }
    }
}